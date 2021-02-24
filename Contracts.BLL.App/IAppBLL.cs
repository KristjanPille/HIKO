using Contracts.BLL.App.Services;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IFormService Forms { get; }
    }
}