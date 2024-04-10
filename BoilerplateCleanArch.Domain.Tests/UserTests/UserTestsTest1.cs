using BoilerplateCleanArch.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace BoilerplateCleanArch.Domain.Tests.UserTests
{
    public class UserTestsTest1
    {
        [Fact(DisplayName = "Create User With Valid State")]
        public void CreateUser_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new User(1, "User Name");
            action.Should()
                  .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateUser_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new User(-1, "User Name");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateUser_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new User(1, "CA");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name, too short, minumum 3 Caracteres");
        }

        [Fact]
        public void CreateUser_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new User(1, "");
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>()
                  .WithMessage($"Invalid name.Name is Required");
        }

        [Fact]
        public void CreateUser_WithNullNameValue_DomainExcpetionInvalidName()
        {
            Action action = () => new User(1, null);
            action.Should()
                  .Throw<Validation.DomainExceptionValidation>();
        }
    }
}
