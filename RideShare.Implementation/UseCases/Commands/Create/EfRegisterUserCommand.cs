using FluentValidation;
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

        public EfRegisterUserCommand(RideshareContext context, RegisterUserValidator validator)
        {
            _context = context;
            _validator = validator;
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
        }
    }
}
