using Brightskies.Restaurant.Application.UnitTest.Common;
using Brightskies.Restaurant.Application.Users.Comands.Login;
using FluentValidation.Validators;
using FluentValidation.Validators.UnitTestExtension.Composer;
using FluentValidation.Validators.UnitTestExtension.Core;
using Xunit;

namespace Brightskies.Restaurant.Application.UnitTest.Users.Commands.Login
{
    public class LoginCommandValidatorTests : CommandTestBase
    {
        private readonly LoginCommandValidators _validator;

        public LoginCommandValidatorTests()
        {
            _validator = new LoginCommandValidators();
        }

        [Fact]
        public void GivenWhenValidatorConstructing_ThenNPropertiesShouldHaveRules()
        {
            // Assert
            _validator.ShouldHaveRulesCount(2);
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