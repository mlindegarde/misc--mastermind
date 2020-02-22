using System;
using System.Collections.Generic;
using System.Text;
using Mastermind.Model;

namespace Mastermind.Ai
{
    public class Solver
    {
        public Solution Crack(Combination combination)
        {
            Solution solution = new Solution();

            List<string> possibilities = GenerateAllPossibilities(combination);

            string guess = GenerateInitialGuess(combination);

            while (!solution.HasAnswer)
            {
                Crack(combination, guess, solution, possibilities);

                guess = possibilities[0];
            }

            return solution;
        }

        private void Crack(Combination combination, string guess, Solution solution, List<string> possibilities)
        {
            Result baseResult = combination.TryGuess(guess);

            solution.Guesses.Add(guess);

            if (baseResult.WasRight)
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
        private string GenerateInitialGuess(Combination combination)
        {
            bool isOdd = combination.Length % 2 == 1;
            int halfLength = combination.Length / 2;

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < halfLength; i++)
            {
                sb.Append("1");
            }

            for(int i = 0; i < halfLength+(isOdd? 1 : 0); i++)
            {
                sb.Append("2");
            }

            return sb.ToString();
        }

        private List<string> GenerateAllPossibilities(Combination combination)
        {
            List<string> solutions = new List<string>();
            Stack<char> currentSolution = new Stack<char>();

            for(int i = combination.MinimumDigit; i <= combination.MaximumDigit; i++)
            {
                currentSolution.Push((char)(48 + i));
                GenerateAllPossibilities(solutions, currentSolution, combination);
                currentSolution.Pop();
            }

            return solutions;
        }

        private void GenerateAllPossibilities(List<string> solutions, Stack<char> currentSolution, Combination combination)
        {
            for(int i = combination.MinimumDigit; i <= combination.MaximumDigit; i++)
            {
                currentSolution.Push((char)(48 + i));

                if(currentSolution.Count == combination.Length)
                    solutions.Add(new String(currentSolution.ToArray()));
                else
                    GenerateAllPossibilities(solutions, currentSolution, combination);

                currentSolution.Pop();
            }
        }
        #endregion
    }
}
