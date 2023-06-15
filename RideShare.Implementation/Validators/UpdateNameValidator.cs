using FluentValidation;
using RideShare.Application.UseCases.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class UpdateNameValidator : AbstractValidator<UpdateNameDto>
    {
        public UpdateNameValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty().WithMessage("New name of brand must be provided.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must be provided.");
        }
    }
}
