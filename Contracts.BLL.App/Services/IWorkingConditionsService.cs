using System.Threading.Tasks;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using WorkingConditions = BLL.App.DTO.WorkingConditions;

namespace Contracts.BLL.App.Services
{
    public interface IWorkingConditionsService : IBaseEntityService<WorkingConditions>, IFormRepositoryCustom<WorkingConditions>
    {
  
    }
}