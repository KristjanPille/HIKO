using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Company, DAL.App.DTO.Company>,
        ICompanyRepository
    {
        public CompanyRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.Company, DTO.Company>())
        {
        }
        
        public override async Task<IEnumerable<DTO.Company>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            query = query
                .Include(g => g.WorkCategories)
                .ThenInclude(f => f.Forms)
                .ThenInclude(f => f.WorkingConditions)
                .Include(g => g.WorkCategories)
                .ThenInclude(f => f.Forms)
                .ThenInclude(f => f.Additional)
                .Include(g => g.WorkCategories)
                .ThenInclude(f => f.Forms)
                .ThenInclude(f => f.BodyPostures);

            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;

        }
    }
}