using Serilog.Events;

namespace Mastermind.Application
{
    public class Settings
    {
        #region Properties
        public int CombinationLength { get; set; }
        public int MinimumDigit { get; set; }
        public int MaximumDigit { get; set; }
        public int GuessLimit { get; set; }

        public LogEventLevel MinimumLogLevel { get; set; }
        #endregion

        #region Methods
        public bool AreValid()
        {
            if (CombinationLength < 1 || CombinationLength > 9)
                return false;

            if (MinimumDigit < 0 || MinimumDigit > 9 || MinimumDigit >= MaximumDigit)
                return false;

            if (MaximumDigit < MinimumDigit || MaximumDigit > 9)
                return false;

            if (GuessLimit > 100)
                return false;

            return true;
        }
        #endregion
    }
}
