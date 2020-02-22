using System;
using System.Text;

namespace Mastermind
{
    public class Result : IEquatable<Result>
    {
        #region Properties
        public int ExactlyRight { get; set; } = 0;
        public int SortaRight { get; set; } = 0;
        #endregion

        #region Wrapper Properties
        public bool WasSuccessful => ExactlyRight == 4;
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
        public static implicit operator string(Result result) => result.ToString();
        #endregion

        #region IEquatable Implementation
        public bool Equals(Result other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            return ExactlyRight == other.ExactlyRight && SortaRight == other.SortaRight;
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals((Result)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ExactlyRight * 397) ^ SortaRight;
            }
        }
        #endregion
    }
}
