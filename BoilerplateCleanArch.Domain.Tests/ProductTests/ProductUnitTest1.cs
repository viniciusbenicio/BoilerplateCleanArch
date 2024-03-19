using BoilerplateCleanArch.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace BoilerplateCleanArch.Domain.Tests.ProductTests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "P", "Product Description", 9.99m, 99, "product image");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minumum 3 Caracteres");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpgproduct image.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg.jpg");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid image name, too long, maximum 250 Caracteres");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainExcpetion()
        {
            Action action = () => new Product(1, "Procut Name", "Product Description", 9.99m, 99, null);
            action.Should()
                  .NotThrow<Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Procut Name", "Product Description", 9.99m, 99, null);
            action.Should()
                  .NotThrow<NullReferenceException>();
        }
        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainExcpetion()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should()
                  .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExecptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value, "product image");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid stock value");
        }

        [Theory]
        [InlineData(-99.9)]
        public void CreateProduct_InvalidPriceValue_ExecptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Prorduct Name", "Product Description", value, 1, "product image");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid price value");
        }
    }
}
