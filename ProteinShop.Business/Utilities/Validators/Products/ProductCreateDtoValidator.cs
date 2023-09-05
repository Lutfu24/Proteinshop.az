using FluentValidation;
using ProteinShop.Entities.Dtos.Product;

namespace ProteinShop.Business.Utilities.Validators.Products;

public class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto>
{
	public ProductCreateDtoValidator()
	{
		RuleFor(p => p.Name).NotEmpty();
	}
}
