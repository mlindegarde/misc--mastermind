using System.Collections.Generic;

namespace Mastermind.Application
{
    public class ValidationResult
    {
        #region Properties
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        #endregion

        #region Factory Methods
        public static ValidationResult Success()
        {
            return new ValidationResult {IsValid = true};
        }
        #endregion
    }
}
