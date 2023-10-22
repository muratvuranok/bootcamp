using BootCamp.FirstWebApi.Models;
using FluentValidation;

namespace BootCamp.FirstWebApi.Validations;

public class ShipperCreateInputValidator : AbstractValidator<ShipperCreateInput>
{
    public ShipperCreateInputValidator()
    {
        RuleFor(r => r.CompanyName).NotEmpty().WithMessage("Şirket Adı, boş geçilemez");
        RuleFor(r => r.CompanyName).MaximumLength(150).WithMessage("Şirket Adı, 150 karakterden fazla olamaz");
        RuleFor(r => r.CompanyName).MinimumLength(3).WithMessage("Şirket Adı, 3 karakterden az olamaz");
    }
}