using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class BodyPosturesRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.BodyPostures, DAL.App.DTO.BodyPostures>,
        IBodyPosturesRepository
    {
        public BodyPosturesRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.BodyPostures, DTO.BodyPostures>())
        {
        }
    }
}