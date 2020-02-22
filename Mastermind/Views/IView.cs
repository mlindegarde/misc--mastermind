using Mastermind.Presenters;

namespace Mastermind.Views
{
    public interface IView<TPresenter> where TPresenter : IPresenter
    {
        #region Properties
        string Title { get; }
        TPresenter Presenter { get; set; }
        #endregion

        #region Methods
        void Render();
        void RenderError(string errorMessage);
        #endregion
    }
}
