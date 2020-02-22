using System.Threading.Tasks;

namespace Mastermind.Presenters
{
    public interface IPresenter
    {
        Task<IPresenter> PresentAsync();
    }
}
