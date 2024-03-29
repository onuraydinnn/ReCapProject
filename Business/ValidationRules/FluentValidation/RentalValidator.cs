﻿using Core.Utilities.Results;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r=>r.CustomerId).NotEmpty();
            RuleFor(r=>r.CarId).NotEmpty();

        }


    }
}
