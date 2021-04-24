using BLL.App.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.carwash.kristjan.BLL.Base;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        public AppBLL(IAppUnitOfWork uow) : base(uow)
        {
        }

        public IFormService Forms =>
            GetService<IFormService>(() => new Services.FormService(UOW));
        
        public IWorkingConditionsService WorkingConditions =>
            GetService<IWorkingConditionsService>(() => new Services.WorkingConditionsService(UOW));
        
        public IAdditionalService Additionals =>
            GetService<IAdditionalService>(() => new Services.AdditionalService(UOW));

        public IBodyPosturesService BodyPosture =>
            GetService<IBodyPosturesService>(() => new Services.BodyPosturesService(UOW));
    }
}