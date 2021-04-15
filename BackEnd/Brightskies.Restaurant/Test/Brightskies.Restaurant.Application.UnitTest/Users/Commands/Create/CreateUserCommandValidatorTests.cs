using Brightskies.Restaurant.Application.UnitTest.Common;
using Brightskies.Restaurant.Application.Users.Comands.Create;
using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Xunit;

namespace Brightskies.Restaurant.Application.UnitTest.Users.Commands.Create
{
    public class CreateUserCommandValidatorTests : CommandTestBase
    {
        private readonly CreateUserCommandValidators _validator;

        public CreateUserCommandValidatorTests()
        {
            _validator = new CreateUserCommandValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(3);
        }

        [Fact]
        public void Given_Name_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Name, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .Create());
        }

        [Fact]
        public void Given_Email_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Email, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<EmailValidator>()
                .Create());
        }

        [Fact]
        public void Given_Password_IsEmpty_When_Validating_Then_Error()
        {
            // Assert
            _validator.ShouldHaveRules(x => x.Password, BaseVerifiersSetComposer.Build()
                .AddPropertyValidatorVerifier<NotEmptyValidator>()
                .AddPropertyValidatorVerifier<MinimumLengthValidator>()
                .Create());
        }
    }
}