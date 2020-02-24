using FluentAssertions;
using Mastermind.Application;
using Xunit;

namespace Mastermind.Tests.Application
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData("4444")]
        [InlineData("1122")]
        public void Should__ReturnSuccess__When__InputIsValid(string input)
        {
            // arrange
            InputValidator inputValidator = new InputValidator(GenerateSettings());

            // act
            ValidationResult result = inputValidator.Validate(input);

            // assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should__ReturnMultipleErrors__When__InputViolatesMultipleRules()
        {
            // arrange
            InputValidator inputValidator = new InputValidator(GenerateSettings());
            string input = "93424";

            // act
            ValidationResult result = inputValidator.Validate(input);

            // assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(2);
        }

        #region Utility Methods
        private Settings GenerateSettings(int combinationLength = 4, int minDigit = 1, int maxDigit = 6)
        {
            return
                new Settings
                {
                    CombinationLength = combinationLength,
                    MinimumDigit = minDigit,
                    MaximumDigit = maxDigit,
                    GuessLimit = 10
                };
        }
        #endregion
    }
}
