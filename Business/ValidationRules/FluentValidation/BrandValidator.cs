using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b=>b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(2).WithMessage("Minimum 2 harf olmalı");
            RuleFor(b => b.BrandName).Must(FirstLetterUpperCase).WithMessage("Marka büyük harf ile başlamalı");
        }
        private bool FirstLetterUpperCase(string brandName)
        {
            char name = brandName[0];
            if (char.IsUpper(name))
            {
                return true;
            }
            return false;
        }

    }
}
