using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(4).WithMessage("minimum uzunlugu 4 olmalidir").NotEmpty().WithMessage("bosh gonderile bilmez");
            RuleFor(p => p.Price).GreaterThan(0).NotEmpty().WithMessage("bosh gonderile bilmez");
        }
    }
}
