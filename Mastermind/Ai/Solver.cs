using System;
using System.Collections.Generic;
using System.Text;
using Mastermind.Application;
using Mastermind.Model;

namespace Mastermind.Ai
{
    /// <summary>
    /// This class implements the Swaszek solution to the Mastermind game.  I choose
    /// to use it because it seemed incredibly easy to implement.  As a bonus, it
    /// apparently performs better than your typical implementation of the Knuth 5
    /// guess algorithm.
    ///
    /// The general algorithm:
    /// - Start with 1122 as your first guess
    /// - After getting that result, eliminate for the list off all possibilities any
    ///   possibility that would not give you the same result if it were the answer
    /// - Pick the first element from the list of possibilities and repeat
    /// </summary>
    public class Solver
    {
        #region Methods
        public Solution Crack(Combination combination)
        {
            Solution solution = new Solution();

            // Use the information about the combination to generate all possible
            // solutions.
            List<string> possibilities = GenerateAllPossibilities(combination);

            // For a 4 digit combination 1144 works.  According to this UR:
            // https://arxiv.org/pdf/1305.1010.pdf you would use 11223 for a five digit
            // combination.  This code extrapolates that out for longer combinations.
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
            GuessResult baseResult = combination.Try(guess);

            solution.Guesses.Add(guess);

            if (baseResult.WasRight)
            {
                solution.Answer = guess;
                return;
            }
            
            // I'm going to modify the collection, with that in mind we won't use
            // a foreach loop.
            for (int i = 0; i < possibilities.Count; i++)
            {
                GuessResult result = combination.Try(guess, possibilities[i]);

                if(!result.Equals(baseResult))
                {
                    possibilities.Remove(possibilities[i]);
                    i--;
                }
            }
        }
        #endregion

        #region Utility Methods
        private string GenerateInitialGuess(Combination combination)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0, digit = 1; i < combination.Length; i++)
            {
                sb.Append(digit);

                // If we've already used a digit twice, increment to the next digit.
                if(i % 2 == 1)
                    digit++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates all combinations up to N digits long using only digits that are
        /// withing the range used by the combination.
        /// </summary>
        /// <remarks>
        /// This was an interesting bit to solve.  If I wanted to hard coded the combination
        /// length I could have easily used nested loops.  I don't know the length of the
        /// combination so I used recursion and a stack instead.
        /// </remarks>
        /// <param name="combination"></param>
        /// <returns></returns>
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
                    // Once the maximum length has been reached, add the solution to 
                    // the list of all possible solutions.
                    GenerateAllPossibilities(solutions, currentSolution, combination);

                currentSolution.Pop();
            }
        }
        #endregion
    }
}
