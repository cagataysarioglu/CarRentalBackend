using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
            RuleFor(c => c.Name).Must(Normalized);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(530).When(c => c.BrandId == 1);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(500).When(c => c.BrandId == 6);
        }

        private bool Normalized(string arg)
        {
            return arg.IsNormalized();
        }
    }
}
