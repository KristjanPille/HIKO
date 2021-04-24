using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WorkingConditionsRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.WorkingConditions, DAL.App.DTO.WorkingConditions>,
        IWorkingConditionsRepository
    {
        public WorkingConditionsRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.WorkingConditions, DTO.WorkingConditions>())
        {
        }
    }
}