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

        [Fact]
        public void Should__IndicateWhatIsRight__When__GuessIsPartiallyCorrect()
        {
            // arrange
            Combination combination =
                new CombinationBuilder()
                    .WithLength(4)
                    .UsingDigitsBetween(1, 6);

            char[] guess = combination.GetAnswer().ToArray();
            guess[3] = guess[3] == '1'? '2': '1';

            // act
            GuessResult result = combination.Try(new String(guess));

            // assert
            result.WasRight.Should().BeFalse();
            result.ToString().Should().Be("+++");
        }
    }
}
