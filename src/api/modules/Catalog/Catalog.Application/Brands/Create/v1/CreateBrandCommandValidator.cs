using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Brands.Create.v1;
public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
    }
}
