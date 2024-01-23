using FluentValidation;
using NTierArchitecture.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Service.Validations
{
    public class JourneyDtoValidator: AbstractValidator<JourneyDto>
    {
        public JourneyDtoValidator()
        {
            RuleFor(x => x.DepartureLocation).NotNull().WithMessage("Kalkış yeri null geçilemez.").NotEmpty().WithMessage("{PropertyName} boş geçilemez.");

            RuleFor(x => x.ArrivalLocation).NotNull().WithMessage("Varış yeri null geçilemez.").NotEmpty().WithMessage("{PropertyName} boş geçilemez.");

            RuleFor(x => x.JourneyDate).NotNull().WithMessage("Seyahat tarihi null geçilemez.").NotEmpty().WithMessage("{PropertyName} boş geçilemez.");
        }
    }
}
