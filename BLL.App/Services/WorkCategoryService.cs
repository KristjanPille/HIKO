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
    public class WorkCategoryService : BaseEntityService<IAppUnitOfWork, IWorkCategoryRepository, IWorkCategoryServiceMapper,
        WorkCategory, DTO.WorkCategory>, IWorkCategoryService
    {
        public WorkCategoryService(IAppUnitOfWork uow) : base(uow, uow.WorkCategories,
            new WorkCategoryServiceMapper())
        {
            
        }
        public double WorkCategoryAverageScore(DTO.WorkCategory workCategory)
        {
            var averageScore = 0.0;
            if (workCategory.Forms.Count > 0)
            {
                averageScore += workCategory.Forms.Sum(form => form.TotalPoints);

                averageScore /= workCategory.Forms.Count;
            }
            return averageScore;
        }
    }
}