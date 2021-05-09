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
        
        public virtual async Task<IEnumerable<DTO.Company>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            List<Domain.App.Company> comapnies = new List<Domain.App.Company>();

            var query = PrepareQuery(userId, noTracking);

            foreach (var company in query)
            {
                company.WorkCategories = await RepoDbContext.Work.AsNoTracking()
                    .Where(l => l.CompanyId == company.Id)
                    .ToListAsync();
                
                comapnies.Add(company);
            }
            var result = comapnies.Select(e => Mapper.Map(e));
            return result;
        }
    }
}