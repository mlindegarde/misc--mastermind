using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Mastermind.Application;
using Mastermind.Model;
using Xunit;

namespace Mastermind.Tests.Application
{
    public class CombinationBuilderTests
    {
        [Fact]
        public void Should__Generate6DigitCombination__When__CombinationLengthIs6()
        {
            // arrange
            const int combinationLength = 6;

            // act
            Combination combination =
                new CombinationBuilder()
                    .WithLength(combinationLength)
                    .UsingDigitsBetween(1, 9);

            // assert
            combination.Length.Should().Be(combinationLength);
        }

        [Fact]
        public void Should__GenerateCombinationWithDigitsInRange__When__ValidRangeGiven()
        {
            // arrange
            List<int> range = Enumerable.Range(1, 3).ToList();
            const int combinationLength = 10;

            // act
            Combination combination =
                new CombinationBuilder()
                    .WithLength(combinationLength)
                    .UsingDigitsBetween(range.First(), range.Last());

            string answer = combination.GetAnswer();

            // assert
            answer.ToArray().All(c => range.Contains(c - 48)).Should().BeTrue();
        }
    }
}
