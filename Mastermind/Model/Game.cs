﻿using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Ai;
using Mastermind.Application;

namespace Mastermind.Model
{
    public class Game
    {
        #region Member Variables
        private readonly Settings _settings;
        private readonly InputValidator _inputValidator;
        private readonly Solver _solver;

        private Combination _combination;
        private List<GuessResult> _history;
        #endregion

        #region Properties
        // Readonly properties used to tell the Program the game's current state.
        public bool IsOver => _history?.Count == _settings.GuessLimit || _history?.LastOrDefault()?.WasRight == true;
        public bool WasSuccessful => _history?.LastOrDefault()?.WasRight == true;
        #endregion

        #region Constructor
        public Game(Settings settings, InputValidator inputValidator, Solver solver)
        {
            // These values come from the IoC container.
            _settings = settings;
            _inputValidator = inputValidator;
            _solver = solver;
        }
        #endregion

        #region Methods
        public void Init()
        {
            // Create a new combination using values from the appsettings.json file.
            _combination =
                new CombinationBuilder()
                    .WithLength(_settings.CombinationLength)
                    .UsingDigitsBetween(_settings.MinimumDigit, _settings.MaximumDigit);

            _history = new List<GuessResult>();
        }

        public void DisplayRules()
        {
            Console.WriteLine("THE RULES:");
            Console.WriteLine($"  - Your guess must be {_settings.CombinationLength} digits long");
            Console.WriteLine($"  - Your guess must use digits between {_settings.MinimumDigit} and {_settings.MaximumDigit}");
            Console.WriteLine("  - A '+' means you got a digit exactly right");
            Console.WriteLine("  - A '-' means you got the digit right, but not the location");
            Console.WriteLine();
        }

        public void Play()
        {
            // This method is repeatedly called from the Program::Run method until IsComplete
            // become true as a result of reaching the guess limit or successfully solving
            // the problem.
            Console.Write($"GUESS #{_history.Count+1:00}: ");
            string input = Console.ReadLine();
            ValidationResult validationResult = _inputValidator.Validate(input);

            // Don't except invalid input.  That could cause some real problems.
            if(!validationResult.IsValid)
            {
                DisplayErrors(validationResult);
                return;
            }

            GuessResult result = _combination.Try(input);

            Console.WriteLine($"RESULT: {result}{Environment.NewLine}");
            _history.Add(result);
        }

        public void DisplayResults()
        {
            string result = _history.Last().WasRight
                ? "Congratulations, your guess was right"
                : $"You have used all {_settings.GuessLimit} of your guesses.  The answer was {_combination.GetAnswer()}.";

            Console.WriteLine(result);
        }

        public void ShowHowItsDone()
        {
            // Let the solver show the user a relatively optimal path of guesses that
            // would have lead to the correct answer.  In reality humans will never be
            // able to pull this off.
            Solution solution = _solver.Crack(_combination);

            Console.WriteLine();
            Console.WriteLine("You should have tried:");
            Console.WriteLine(String.Join(Environment.NewLine, solution.Guesses.Select(g => $"  - {g} = {_combination.Try(g)}")));
            Console.WriteLine();
            Console.WriteLine($"That would have gotten you to {_combination.GetAnswer()}.");
            Console.WriteLine();
        }

        public void PauseForEffect()
        {
            Console.WriteLine("Press ENTER to exit: ");
            Console.ReadLine();
        }

        private void DisplayErrors(ValidationResult validationResult)
        {
            Console.WriteLine("Please correct the following errors with your guess:");

            foreach (string error in validationResult.Errors)
                Console.WriteLine($"  - {error}");

            Console.WriteLine();
        }
        #endregion
    }
}
