using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AppUserRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Identity.AppUser, DAL.App.DTO.Identity.AppUser>,
        IAppUserRepository
    {
        public AppUserRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.Identity.AppUser, DTO.Identity.AppUser>())
        {
        }
        
        public override async Task<IEnumerable<DTO.Identity.AppUser>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            query = query.Include(t => t.Forms);

            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;

        }
    }
}