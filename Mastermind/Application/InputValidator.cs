using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mastermind.Application
{
    public class InputValidator
    {
        #region Member Variables
        private readonly Settings _settings;
        private readonly Regex _regex;
        #endregion

        #region Constructor
        public InputValidator(Settings settings)
        {
            _settings = settings;

            // The length of the combination is not hard coded nor is the valid digit
            // range, generate the regex dynamically.
            _regex = 
                new Regex(
                    $"$[{settings.MinimumDigit}-{settings.MaximumDigit}]{{{settings.CombinationLength}}}^", 
                    RegexOptions.Compiled);
        }
        #endregion

        public ValidationResult Validate(string input)
        {
            // First do a quick check to see if everything is okay.  If it is, just
            // return now and skip the below checks.
            if (_regex.IsMatch(input))
                return ValidationResult.Success();

            // I prefer to tell the user everything they got wrong at once rather than
            // make them find out mistakes one at a time.  That's just a bad UX.
            List<string> errors = new List<string>();

            if(input.Length != _settings.CombinationLength)
                errors.Add($"You guess must be exactly {_settings.CombinationLength} digits long");

            foreach(char d in input)
            {
                int digit = d - 48;

                if(digit < _settings.MinimumDigit || digit > _settings.MaximumDigit)
                    errors.Add($"{digit} is not between {_settings.MinimumDigit} and {_settings.MaximumDigit}");
            }

            return
                new ValidationResult
                {
                    IsValid = !errors.Any(),
                    Errors = errors
                };
        }
    }
}
