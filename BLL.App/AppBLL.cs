using BLL.App.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
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
        
        public ICompanyService Companies =>
            GetService<ICompanyService>(() => new Services.CompanyService(UOW));
        
        public IWorkCategoryService WorkCategories =>
            GetService<IWorkCategoryService>(() => new Services.WorkCategoryService(UOW));
    }
}