using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Brands.Update.v1;
public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
    }
}
