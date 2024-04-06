using aplication.Dtos.Products;
using FluentValidation;

namespace aplication.Validators.ProductValidator;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("O campo nome é obrigatorio");

        RuleFor(p => p.Description).MaximumLength(200).WithMessage("Tamanho máximo de 200 caracteres");

        RuleFor(p => p.PlantingDate).NotNull().NotEmpty().WithMessage("Data de plantio é orbigatorio");
    }
}