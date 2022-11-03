using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product With Valid Parameters")]
    [Trait("Product", "Create Product")]
    public void CreateProduct_WithValidaParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, "product image");

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product With Negative Id Value")]
    [Trait("Product", "Create Product")]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 9.9m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid id value.");
    }

    [Fact(DisplayName = "Create Product With Short Name")]
    [Trait("Product", "Create Product")]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Pr", "Product Description", 9.9m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 charecters.");
    }

    [Fact(DisplayName = "Create Product With Long ImageName")]
    [Trait("Product", "Create Product")]
    public void CreateProduct_LongImageName_DomainExceptionImageName()
    {
        var imageName = "";

        for (int i = 0; i < 260; i++)
        {
            imageName += "a";
        }

        Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, imageName);

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 250 characteres");
    }

    [Fact(DisplayName = "Create Product With Empty ImageName")]
    [Trait("Product", "Create Product")]
    public void CreateProduct_WithEmptyImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, "");

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product With Null ImageName")]
    [Trait("Product", "Create Product")]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, 99, null);

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product Invalid Price Value")]
    [Trait("Product", "Create Product")]
    public void CreateProduct_InvalidPriceValue_DomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", -9.9m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Theory(DisplayName = "Created Product With Invalid Stock value")]
    [InlineData(-5)]
    [Trait("Product", "Create Product")]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegative(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.9m, value, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}