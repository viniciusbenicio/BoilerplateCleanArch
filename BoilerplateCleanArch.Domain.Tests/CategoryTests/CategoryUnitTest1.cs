using BoilerplateCleanArch.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace BoilerplateCleanArch.Domain.Tests.CategoryTests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                  .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "CA");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minumum 3 Caracteres");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage($"Invalid name.Name is Required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExcpetionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>();
        }
    }
}
