using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RideShare.API.DTOs;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using RideShare.API.JWT;
using System.Linq;
using System.Threading.Tasks;
using RideShare.Implementation.Validators;

namespace RideShare.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void addValidators(this IServiceCollection services)
        {
            services.AddTransient<OnlyNameValidator>();
            services.AddTransient<CreateModelValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreateTypeValidator>();
            services.AddTransient<CreateCarValidator>();
            services.AddTransient<CreateColorValidator>();
            services.AddTransient<CreateRestrictionValidator>();
            services.AddTransient<DeleteRestrictionValidator>();
            services.AddTransient<DeleteColorValidator>();
            services.AddTransient<DeleteModelValidator>();
            services.AddTransient<CreateRideValidator>();
            services.AddTransient<SearchUseCaseValidator>();
            services.AddTransient<CreateCarValidator>();
            services.AddTransient<DeleteRideValidator>();
            services.AddTransient<DeleteTypeValidator>();
        }
        public static void addJWT (this IServiceCollection services, AppSettings settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JWT.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JWT.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        //Token dohvatamo iz Authorization header-a

                        var header = context.Request.Headers["Authorization"];

                        var token = header.ToString().Split("Bearer ")[1];

                        var handler = new JwtSecurityTokenHandler();

                        var tokenObj = handler.ReadJwtToken(token);

                        string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;


                        //ITokenStorage

                        ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();

                        bool isValid = storage.TokenExists(jti);

                        if (!isValid)
                        {
                            context.Fail("Token is not valid.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
