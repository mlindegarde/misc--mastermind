using FluentAssertions;
using Mastermind.Ai;
using Mastermind.Application;
using Mastermind.Model;
using Xunit;

namespace Mastermind.Tests.Ai
{
    public class SolverTests
    {
        [Theory]
        [InlineData(4, 1, 6)]
        [InlineData(5, 1, 9)]
        [InlineData(2, 7, 9)]
        public void Should__FindSolution__When__SolutionExists(int combinationLength, int minDigit, int maxDigit)
        {
            // arrange
            Combination combination =
                new CombinationBuilder()
                    .WithLength(combinationLength)
                    .UsingDigitsBetween(minDigit, maxDigit);

            Solver solver = new Solver();

            // act
            Solution solution = solver.Crack(combination);

            // assert
            solution.HasAnswer.Should().BeTrue();
            solution.Answer.Should().Be(combination.GetAnswer());
        }
    }
}
