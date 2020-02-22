using System.Collections.Generic;

namespace Mastermind
{
    public class Solver
    {
        public Solution Solve(Game game)
        {
            Solution solution = new Solution();

            List<char[]> possibilities = GenerationAllPossibilities();
            char[] guess = { '1', '1', '2', '2' };

            while (!solution.HasAnswer)
            {
                Solve(game, guess, solution, possibilities);

                guess = possibilities[0];
            }

            return solution;
        }

        private void Solve(Game game, char[] guess, Solution solution, List<char[]> possibilities)
        {
            Result baseResult = game.CheckGuess(guess);

            solution.Guesses.Add(guess);

            if (baseResult == "++++")
            {
                solution.Answer = guess;
                return;
            }

            for (int i = 0; i < possibilities.Count; i++)
            {
                Result result = game.CheckGuess(guess, possibilities[i]);

                if (!result.Equals(baseResult))
                {
                    possibilities.Remove(possibilities[i]);
                    i--;
                }
            }
        }

        #region Utility Methods
        private List<char[]> GenerationAllPossibilities()
        {
            List<char[]> solutions = new List<char[]>();

            for (int a = 1; a <= 6; a++)
            {
                for (int b = 1; b <= 6; b++)
                {
                    for (int c = 1; c <= 6; c++)
                    {
                        for (int d = 1; d <= 6; d++)
                        {
                            solutions.Add(
                                new[]
                                {
                                    (char)(a + 48),
                                    (char)(b + 48),
                                    (char)(c + 48),
                                    (char)(d + 48)
                                });
                        }
                    }
                }
            }

            return solutions;
        }
        #endregion
    }
}
