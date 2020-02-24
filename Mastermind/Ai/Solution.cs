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
        /// <summary>
        /// A shortcut that lets you display the Solution object as a string when
        /// there is a good reason to do so.
        /// </summary>
        /// <param name="solution">Solution object to convert to a string</param>
        public static implicit operator string(Solution solution) => solution.ToString();
        #endregion
    }
}
