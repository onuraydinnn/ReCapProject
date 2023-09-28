using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c=>c.ColorName).NotEmpty();
            RuleFor(c => c.ColorName).Must(DoesNotContainNumber).WithMessage("Renk sayı içermemelidir");

        }
        private bool DoesNotContainNumber(string colorName)
        {
            foreach (char item in colorName)
            {
                if (char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
