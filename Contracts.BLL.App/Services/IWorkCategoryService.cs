using System.Threading.Tasks;
using BLL.App.DTO;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Form = BLL.App.DTO.Form;

namespace Contracts.BLL.App.Services
{
    public interface IWorkCategoryService : IBaseEntityService<WorkCategory>, IWorkCategoryRepositoryCustom<WorkCategory>
    {
        double WorkCategoryAverageScore(WorkCategory workCategory);
    }
}