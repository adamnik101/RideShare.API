using FluentValidation;
using RideShare.Application.Emails;
using RideShare.Application.UseCases.Commands.Create;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.DataAccess;
using RideShare.Domain.Entities;
using RideShare.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.UseCases.Commands.Create
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly RideshareContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _emailSender;

        public EfRegisterUserCommand(RideshareContext context, RegisterUserValidator validator, IEmailSender emailSender)
        {
            _context = context;
            _validator = validator;
            _emailSender = emailSender;
        }

        public int Id => 100;

        public string Name => "Register new user using Entity Framework";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);
            Role defaultRole = _context.Roles.FirstOrDefault(x => x.IsDefault);

            if (defaultRole == null)
            {
                throw new InvalidOperationException("Default role does not exist.");
            }
            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Role = defaultRole,
                GenderId = request.GenderId,
                Password = hash,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            /*_emailSender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successful registration!",
                Body = "Welcome to Rideshare. Hope you enjoy using our services!"
            });*/
        }
    }
}
