using System.Collections.Generic;

namespace Mastermind.Ai
{
    public class Solution
    {
        #region Properties
        public string Answer { get; set; }
        public List<string> Guesses { get; set; } = new List<string>();
        #endregion

        #region Wrapper Properties
        public bool HasAnswer => Answer != null;
        #endregion

        #region Overrides
        public override string ToString()
        {
            return Answer ?? "Unknown";
        }
        #endregion

        #region Operators
        public static implicit operator string(Solution solution) => solution.ToString();
        #endregion
    }
}
