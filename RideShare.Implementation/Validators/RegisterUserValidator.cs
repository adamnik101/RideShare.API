using FluentValidation;
using RideShare.Application.UseCases.DTOs.Create;
using RideShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        private const int MaxAge = 65;
        private int CurrentYear = DateTime.Now.Year;
        public RegisterUserValidator(RideshareContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(30).WithMessage("First name is too long.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50).WithMessage("Last name is too long.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is in wrong format.")
                .Must(y => !context.Users.Any(x => x.Email == y))
                .WithMessage("Email is already taken by another existing user.");

            RuleFor(x => x.GenderId)
                .NotEmpty().WithMessage("Gender is required")
                .Must(y => context.Genders.Any(x => x.Id == y)).WithMessage("Gender does not exists");

            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .Must(BeValidDate).WithMessage("Date time is not valid")
                .Must(BeLegalUserAge).WithMessage("You have to be over 18 years old to apply")
                .Must(NotBeOlderThan).WithMessage($"You cannot be older than {MaxAge} years");


        }
        protected bool NotBeOlderThan(DateTime time)
        {
            //2023 - 1953 = 70
            if(CurrentYear - time.Year > MaxAge)
            {
                return false;
            }

            return true;
        }
        protected bool BeValidDate(DateTime time)
        {
            if(time.Day < 1 || time.Day > DateTime.DaysInMonth(time.Year, time.Month))
            {
                return false;
            }

            return true;
        }
        protected bool BeLegalUserAge(DateTime time)
        {
            int userYear = time.Year;

            int over18 = CurrentYear - userYear;

            if (over18 < 18) return false;

            return true;
        }
    }
}
