using System.Threading.Tasks;

namespace Mastermind.Presenters
{
    public interface IPresenter
    {
        #region Properties
        string DefaultInput { get; }
        #endregion

        #region Methods
        Task<IPresenter> PresentAsync();
        #endregion
    }
}
