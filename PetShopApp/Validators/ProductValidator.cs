using System;
using FluentValidation;
using Pet_Store_Application;

public class ProductValidator : AbstractValidator<Product>
{
	public ProductValidator()
	{
		RuleFor(product => product.Name).NotEmpty();
        RuleFor(product => product.Price).GreaterThan(0);
        RuleFor(product => product.Quantity).GreaterThan(0);
        RuleFor(product => product.Description).Must(description => description == null || description.Length > 10).WithMessage("The description must longer than 10 characters");
    }
}
