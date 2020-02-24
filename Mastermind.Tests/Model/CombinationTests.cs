using System;
using System.Linq;
using FluentAssertions;
using Mastermind.Application;
using Mastermind.Model;
using Xunit;

namespace Mastermind.Tests.Model
{
    public class CombinationTests
    {
        [Fact]
        public void Should__IndicateSuccess__When__GuessMatchesAnswer()
        {
            // arrange
            Combination combination =
                new CombinationBuilder()
                    .WithLength(4)
                    .UsingDigitsBetween(1, 6);

            string guess = combination.GetAnswer();

            // act
            GuessResult result = combination.Try(guess);

            // assert
            result.WasRight.Should().BeTrue();
            result.ToString().Should().Be("++++");
        }

        [Theory]
        [InlineData("1122", "1123", "+++")]
        [InlineData("1122", "2211", "----")]
        [InlineData("1122", "1261", "+--")]
        public void Should__IndicateWhatIsRight__When__GuessIsPartiallyCorrect(string answer, string guess, string expectedResult)
        {
            // arrange
            Combination combination = new Combination(answer, 1, 6);

            // act
            GuessResult result = combination.Try(guess);

            // assert
            result.WasRight.Should().BeFalse();
            result.ToString().Should().Be(expectedResult);
        }
    }
}
