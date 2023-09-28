using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.FullName).NotEmpty();
            RuleFor(p => p.CardNumber).Length(16).WithMessage("Kart numarası 16 karakter olmalı");
            RuleFor(p => p.CVV).MinimumLength(3).WithMessage("CVV numarası en az 3 karakter olmalı");
            RuleFor(p => p.Year).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Yıl geçersiz");
            RuleFor(p => p.Month).InclusiveBetween(1, 12).WithMessage("Ay geçersiz");

        }
    }
}
