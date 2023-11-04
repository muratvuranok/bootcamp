using FluentValidation;

namespace BootCamp.FirstWebApi.Validations;
public class CategoryCreateInputValidator : AbstractValidator<CategoryCreateInput>
{
    public CategoryCreateInputValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage("Kategori Adı, boş geçilemez");
        RuleFor(r => r.Name).MaximumLength(150).WithMessage("Kategori Adı, 150 karakterden fazla olamaz");
        RuleFor(r => r.Name).MinimumLength(3).WithMessage("Kategori Adı, 3 karakterden az olamaz");
    }
}
