using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class PortfolioValidator : AbstractValidator<Portfolio>
{
    public PortfolioValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez");
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
        RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel 2 alanı boş geçilemez");
        RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
        RuleFor(x => x.Name).MinimumLength(4).WithMessage("Proje adı en az 4 karakterden oluşmalıdır.");
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje adı en fazla 100 karakter olmalıdır.");

    }
}