using FluentValidation;
using RideShare.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Implementation.Validators
{
    public class SearchUseCaseValidator : AbstractValidator<SearchUseCaseLog>
    {
        public SearchUseCaseValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UseCaseName).NotEmpty().WithMessage("You must provide use case name.");
            RuleFor(x => x.DateFrom).NotEmpty().WithMessage("Date from is required.")
                    .Must(DateDiffLessThan10Days).WithMessage("Date difference must be less than 10 days");
            RuleFor(x => x.DateTo).NotEmpty().WithMessage("Date to is required.");
        }

        protected bool DateDiffLessThan10Days(SearchUseCaseLog search, DateTime? dateFrom)
        {
            if(!search.DateTo.HasValue)
            {
                return false;   
            }
            var timespan = (search.DateTo - search.DateFrom).Value;

            return timespan.TotalDays <= 15;
        }
    }
}
