using FluentAssertions;
using Mastermind.Application;
using Xunit;

namespace Mastermind.Tests.Application
{
    public class GuessResultTests
    {
        [Theory]
        [InlineData(2, 2, "++--")]
        [InlineData(2, 0, "++")]
        [InlineData(1, 1, "+-")]
        [InlineData(0, 3, "---")]
        public void Should__Something__When__True(int exact, int close, string expectedResult)
        {
            // arrange
            GuessResult result = new GuessResult
            {
                ExactlyRight = exact,
                SortaRight = close
            };

            // act
            string resultAsString = (string)result;

            // assert
            resultAsString.Should().Be(expectedResult);
        }

    }
}
