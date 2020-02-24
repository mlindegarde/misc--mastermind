using System.Text;

namespace Mastermind.Application
{
    public class GuessResult
    {
        #region Properties
        public int ExactlyRight { get; set; } = 0;
        public int SortaRight { get; set; } = 0;
        public int CompletelyWrong { get; set; } = 0;
        #endregion

        #region Wrapper Properties
        public bool WasRight => CompletelyWrong == 0 && SortaRight == 0;
        #endregion

        #region Methods
        public bool HasSameIndicatorsAs(GuessResult other)
        {
            return ExactlyRight == other.ExactlyRight && SortaRight == other.SortaRight;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ExactlyRight; i++)
                sb.Append("+");

            for (int i = 0; i < SortaRight; i++)
                sb.Append("-");

            return sb.ToString();
        }
        #endregion

        #region Operators
        public static implicit operator string(GuessResult result) => result.ToString();
        #endregion
    }
}
