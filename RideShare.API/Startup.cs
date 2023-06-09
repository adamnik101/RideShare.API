using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RideShare.DataAccess;
using Microsoft.EntityFrameworkCore;
using RideShare.API.DTOs;
using RideShare.API.JWT;
using RideShare.API.JWT.TokenStorage;
using RideShare.Application;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using RideShare.API.Extensions;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Implementation.UseCases.Commands.Create;
using RideShare.Application.UseCaseHandling;
using RideShare.API.Middleware;
using RideShare.Application.Logging;
using RideShare.API.ErrorLogging;
using RideShare.Application.UseCaseHandling.Query;
using RideShare.Application.UseCaseHandling.Command;
using RideShare.Implementation.Logging;
using RideShare.Application.UseCases.Queries;
using RideShare.Implementation.UseCases.Queries;
using RideShare.Implementation.UseCases.Commands.Delete;
using RideShare.Application.UseCases.Commands.Delete;
using RideShare.Application.Uploads;
using RideShare.Implementation.Uploads;
using RideShare.Application.Emails;
using RideShare.Implementation.Emails;
using RideShare.Application.UseCases.Commands.Update;
using RideShare.Implementation.UseCases.Commands.Update;

namespace RideShare.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);

            services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
            services.AddTransient(x =>
            {
                var context = x.GetService<RideshareContext>();
                var tokenStorage = x.GetService<ITokenStorage>();
                return new JwtManager(context, appSettings.JWT.Issuer, appSettings.JWT.SecretKey, appSettings.JWT.DurationSeconds, tokenStorage);
            });

            services.AddTransient<RideshareContext>(x =>
            {
                DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
                builder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=RideShareV1; Integrated Security=true;");
                return new RideshareContext(builder.Options);
            });

            services.AddHttpContextAccessor();
            services.AddScoped<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var data = header.ToString().Split("Bearer ");

                if (data.Length < 2)
                {
                    return new UnauthorizedActor();
                }

                var handler = new JwtSecurityTokenHandler();

                var tokenObj = handler.ReadJwtToken(data[1].ToString());

                var claims = tokenObj.Claims;

                var email = claims.First(x => x.Type == "Email").Value;
                var id = claims.First(x => x.Type == "Id").Value;
                var fullname = claims.First(x => x.Type == "Fullname").Value;
                var useCases = claims.First(x => x.Type == "UseCases").Value;

                List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

                return new JWTActor
                {
                    Id = int.Parse(id),
                    Fullname = fullname,
                    Email = email,
                    AllowedUseCases = useCaseIds,
                };
            });

           
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RideShare.API", Version = "v1" });
            });
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.addJWT(appSettings);
            services.addValidators();
            services.AddTransient<IQueryHandler>(x =>
            {
                var actor = x.GetService<IApplicationActor>();
                var logger = x.GetService<IUseCaseLogger>();
                var queryHandler = new QueryHandler();
                var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
                var loggingHandler = new LoggingQueryHandler(timeTrackingHandler, actor, logger);
                var decoration = new AuthorizationQueryHandler(actor, loggingHandler);

                return decoration;
            });
            services.AddTransient<ICommandHandler, CommandHandler>();
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            
            //brands
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>(); // create
            services.AddTransient<IReadBrandsQuery, EfReadBrandsQuery>(); // get all
            services.AddTransient<IFindBrandQuery, EfFindBrandQuery>(); // find one
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>(); // update
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>(); // delete one
            //models
            services.AddTransient<ICreateModelCommand, EfCreateModelCommand>(); // create
            services.AddTransient<IReadModelsQuery, EfReadModelsQuery>(); // get all
            services.AddTransient<IFindModelQuery, EfFindModelQuery>(); // find one
            services.AddTransient<IUpdateModelCommand, EfUpdateModelCommand>(); // update
            services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>(); // delete one

            //cities
            services.AddTransient<ICreateCityCommand, EfCreateCityCommand>(); // create
            services.AddTransient<IReadCitiesQuery, EfReadCitiesQuery>(); // get all
            services.AddTransient<IFindCityQuery, EfFindCityQuery>(); // find one
            services.AddTransient<IUpdateCityCommand, EfUpdateCityCommand>(); // update
            services.AddTransient<IDeleteCityCommand, EfDeleteCityCommand>(); // delete one

            //restrictions
            services.AddTransient<ICreateRestrictionCommand, EfCreateRestrictionCommand>(); // create
            services.AddTransient<IReadRestrictionQuery, EfReadRestrictionsQuery>(); // get all
            services.AddTransient<IFindRestrictionQuery, EfFindRestrictionQuery>(); // find one
            services.AddTransient<IUpdateRestrictionCommand, EfUpdateRestrictionCommand>(); // update
            services.AddTransient<IDeleteRestrictionCommand, EfDeleteRestrictionCommand>(); // delete one

            //cars
            services.AddTransient<ICreateCarCommand, EfCreateCarCommand>(); // create
            services.AddTransient<IReadCarsQuery, EfReadCarsQuery>(); // get all
            services.AddTransient<IFindCarQuery, EfFindCarQuery>(); // find one
            services.AddTransient<IDeleteCarCommand, EfDeleteCarCommand>(); // delete one

            //rides
            services.AddTransient<ICreateRideCommand, EfCreateRideCommand>(); // create
            services.AddTransient<IReadRidesQuery,EfReadRidesQuery>(); // get all
            services.AddTransient<IFindRideQuery,EfFindRideQuery>(); // find one
            services.AddTransient<IUpdateRideCommand,EfUpdateRideCommand>(); // update
            services.AddTransient<IDeleteRideCommand, EfDeleteRideCommand>(); // delete one

            //types
            services.AddTransient<ICreateTypeCommand, EfCreateTypeCommand>(); // create
            services.AddTransient<IReadTypesQuery, EfReadTypesQuery>(); // get all
            services.AddTransient<IFindTypeQuery, EfFindTypeQuery>(); // find one
            services.AddTransient<IUpdateTypeCommand, EfUpdateTypeCommand>(); // update
            services.AddTransient<IDeleteTypeCommand, EfDeleteTypeCommand>(); // delete one

            //colors
            services.AddTransient<ICreateColorCommand, EfCreateColorCommand>(); // create
            services.AddTransient<IReadColorsQuery, EfReadColorsQuery>(); // get all
            services.AddTransient<IFindColorQuery, EfFindColorQuery>(); // find one
            services.AddTransient<IUpdateColorCommand, EfUpdateColorCommand>(); // update
            services.AddTransient<IDeleteColorCommand, EfDeleteColorCommand>(); // delete one

            services.AddTransient<IReadUseCaseLogsQuery, EfReadUseCaseLogsQuery>(); // read logs
           
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>(); // register user
            //logger
            services.AddTransient<IErrorLogger, ConsoleErrorLogger>();
            services.AddTransient<IBase64FileUploader, Base64FileUploader>();
            //read user cars
            services.AddTransient<IReadUserCarsQuery, EfReadUserCarsQuery>();  
            services.AddTransient<IReadBrandModelsQuery, EfReadBrandModelsQuery>();

            services.AddTransient<IReadGendersQuery, EfReadGendersQuery>();

            services.AddTransient<ISendRequestCommand, EfSendRequestCommand>();
            services.AddTransient<IReadRidePassengersQuery, EfReadRidePassengersQuery>();
            services.AddTransient<IFindUserQuery, EfFindUserQuery>();
            services.AddTransient<IReadUsersQuery, EfReadUsersQuery>();
            services.AddTransient<IEmailSender>(x =>
            {
               return new SMTPMailSender(appSettings.EmailOptions.FromEmail,
                                         appSettings.EmailOptions.Password,
                                         appSettings.EmailOptions.Port,
                                         appSettings.EmailOptions.Host);
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RideShare.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
