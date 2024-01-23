using FluentValidation;
using NTierArchitecture.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Service.Validations
{
    public class PassportDtoValidator: AbstractValidator<PassportDto>
    {
        public PassportDtoValidator() 
        {
            RuleFor(x => x.ExpiryDate).NotEmpty().WithMessage("Son geçerlilik tarihi boş olamaz")
                .NotNull().WithMessage("Son geçerlilik tarihi null olamaz");
        }   
    }
}
