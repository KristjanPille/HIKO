using Contracts.BLL.App.Services;
using Contracts.DAL.App.Repositories;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IFormService Forms { get; }
        IWorkingConditionsService WorkingConditions { get; }
        IAdditionalService Additionals { get; }
        IBodyPosturesService BodyPosture { get; }
        ICompanyService Companies { get; }
        IWorkCategoryService WorkCategories { get; }
    }
}