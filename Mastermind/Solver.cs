using System.Collections.Generic;

namespace Mastermind
{
    public class Solver
    {
        public Solution Crack(Safe safe)
        {
            Solution solution = new Solution();

            List<string> possibilities = GenerationAllPossibilities();
            string guess = "1122";

            while (!solution.HasAnswer)
            {
                Crack(safe, guess, solution, possibilities);

                guess = possibilities[0];
            }

            return solution;
        }

        private void Crack(Safe safe, string guess, Solution solution, List<string> possibilities)
        {
            Result baseResult = safe.TryCombination(guess);

            solution.Guesses.Add(guess);

            if (baseResult == "++++")
            {
                solution.Answer = guess;
                return;
            }

            for (int i = 0; i < possibilities.Count; i++)
            {
                Result result = Safe.TryCombination(guess, possibilities[i]);

                if (!result.Equals(baseResult))
                {
                    possibilities.Remove(possibilities[i]);
                    i--;
                }
            }
        }

        #region Utility Methods
        private List<string> GenerationAllPossibilities()
        {
            List<string> solutions = new List<string>();

            for (int a = 1; a <= 6; a++)
            {
                for (int b = 1; b <= 6; b++)
                {
                    for (int c = 1; c <= 6; c++)
                    {
                        for (int d = 1; d <= 6; d++)
                        {
                            solutions.Add(
                                new string(new[]
                                {
                                    (char)(a + 48),
                                    (char)(b + 48),
                                    (char)(c + 48),
                                    (char)(d + 48)
                                }));
                        }
                    }
                }
            }

            return solutions;
        }
        #endregion
    }
}
