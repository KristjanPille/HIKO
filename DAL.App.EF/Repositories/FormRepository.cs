using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class FormRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Form, DAL.App.DTO.Form>,
        IFormRepository
    {
        public FormRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.Form, DTO.Form>())
        {
        }
    }
}