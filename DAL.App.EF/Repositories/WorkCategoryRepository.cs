using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class WorkCategoryRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.WorkCategory, DAL.App.DTO.WorkCategory>,
        IWorkCategoryRepository
    {
        public WorkCategoryRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.WorkCategory, DTO.WorkCategory>())
        {
        }
    }
}