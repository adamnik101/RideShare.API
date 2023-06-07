using FluentValidation;
using RideShare.Application.UseCases.DTOs.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class OnlyNameValidator : AbstractValidator<CreateNameOnlyDto>
    {
        public OnlyNameValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}
