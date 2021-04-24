using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class AdditionalRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Additional, DAL.App.DTO.Additional>,
        IAdditionalRepository
    {
        public AdditionalRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.Additional, DTO.Additional>())
        {
        }
    }
}