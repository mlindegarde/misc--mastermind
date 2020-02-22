using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    public class Solution
    {
        #region Properties
        public char[] Answer { get; set; }
        public List<char[]> Guesses { get; set; } = new List<char[]>();
        #endregion

        #region Wrapper Properties
        public bool HasAnswer => Answer != null;
        #endregion

        #region Overrides
        public override string ToString()
        {
            if(Answer == null)
                return "N/A";

            return new String(Answer);
        }
        #endregion

        #region Operators
        public static implicit operator string(Solution solution) => solution.ToString();
        #endregion
    }
}
