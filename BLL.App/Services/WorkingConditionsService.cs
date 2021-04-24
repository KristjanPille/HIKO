using System.Linq;
using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.carwash.kristjan.BLL.Base.Services;

namespace BLL.App.Services
{
    public class WorkingConditionsService : BaseEntityService<IAppUnitOfWork, IWorkingConditionsRepository, IWorkingConditionsServiceMapper,
        WorkingConditions, DTO.WorkingConditions>, IWorkingConditionsService
    {
        public WorkingConditionsService(IAppUnitOfWork uow) : base(uow, uow.WorkingConditions,
            new WorkingConditionsServiceMapper())
        {
            
        }

    }
}