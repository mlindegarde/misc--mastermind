namespace Mastermind.Presenters
{
    public interface IPresenter
    {
        #region Properties
        string DefaultInput { get; }
        #endregion

        #region Methods
        IPresenter Present();
        #endregion
    }
}
