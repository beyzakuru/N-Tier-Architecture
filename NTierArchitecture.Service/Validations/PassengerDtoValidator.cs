using FluentValidation;
using NTierArchitecture.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Service.Validations
{
    public class PassengerDtoValidator: AbstractValidator<PassengerDto>
    {
        public PassengerDtoValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz")
                .NotNull().WithMessage("Kullanıcı adı null olamaz")
                .MaximumLength(30).WithMessage("Kullanıcı adı en fazla 30 karakter olabilir.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Kullanıcı soyadı boş olamaz.")
                .NotNull().WithMessage("Kullanıcı soyadı null olamaz.")
                .MaximumLength(30).WithMessage("Kullanıcı soyadı en fazla 30 karakter olabilir.");

            RuleFor(x => x.EMail).NotEmpty().WithMessage("Email boş olamaz")
                .NotNull().WithMessage("Email null olamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        }  
    }
}
