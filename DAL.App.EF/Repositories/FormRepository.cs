using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain.App;
using ee.itcollege.carwash.kristjan.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Form = DAL.App.DTO.Form;

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
        public override async Task<Form> FirstOrDefaultAsync(Guid id, object? userId, bool noTracking)
        {
            var form = await RepoDbSet.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            form.BodyPostures = await RepoDbContext.BodyPostures.AsNoTracking()
                .Where(l => l.Id == form.BodyPosturesId).FirstOrDefaultAsync();
            
            form.WorkingConditions = await RepoDbContext.WorkingConditions.AsNoTracking()
                .Where(l => l.Id == form.WorkingConditionsId).FirstOrDefaultAsync();
            
            form.Additional = await RepoDbContext.Additionals.AsNoTracking()
                .Where(l => l.Id == form.AdditionalId).FirstOrDefaultAsync();


            return Mapper.Map(form);
        }
        
        public virtual async Task<IEnumerable<DTO.Form>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            List<Domain.App.Form> forms = new List<Domain.App.Form>();

            var query = PrepareQuery(userId, noTracking);

            foreach (var form in query)
            {
                form.BodyPostures = RepoDbContext.BodyPostures.AsNoTracking()
                    .Where(l => l.Id == form.BodyPosturesId).FirstOrDefaultAsync().Result;
            
                form.WorkingConditions = RepoDbContext.WorkingConditions.AsNoTracking()
                    .Where(l => l.Id == form.WorkingConditionsId).FirstOrDefaultAsync().Result;
            
                form.Additional = RepoDbContext.Additionals.AsNoTracking()
                    .Where(l => l.Id == form.AdditionalId).FirstOrDefaultAsync().Result;

                forms.Add(form);
            }
            var result = forms.Select(e => Mapper.Map(e));
            return result;

        }
        
        public async Task<IEnumerable<Form>> GetFormsByName(string filter)
        {
            List<Domain.App.Form> forms = new List<Domain.App.Form>();
            var query = PrepareQuery();

            // only removes trailing leading whitespaces
            filter = filter.Trim();
            
            if (!string.IsNullOrEmpty(filter))
            {
                if (!filter.Any(char.IsWhiteSpace))
                {
                    query = query.Where(f => 
                        f.FirstName.Contains(filter) || 
                        f.LastName.Contains(filter)
                    );   
                }
                // can only be first & lastname
                // this case if both first and lastname entered
                else if (filter.Any(char.IsWhiteSpace))
                {
                    query = query.Where( f =>
                        filter.Contains(f.FirstName) &&
                        filter.Contains(f.LastName) ||
                        filter.Contains(f.FirstName) ||
                        filter.Contains(f.LastName)
                    );   
                }
            }
            
            foreach (var form in query)
            {
                form.BodyPostures = RepoDbContext.BodyPostures.AsNoTracking()
                    .Where(l => l.Id == form.BodyPosturesId).FirstOrDefaultAsync().Result;
            
                form.WorkingConditions = RepoDbContext.WorkingConditions.AsNoTracking()
                    .Where(l => l.Id == form.WorkingConditionsId).FirstOrDefaultAsync().Result;
            
                form.Additional = RepoDbContext.Additionals.AsNoTracking()
                    .Where(l => l.Id == form.AdditionalId).FirstOrDefaultAsync().Result;

                forms.Add(form);
            }
            
            var result = forms.Select(e => Mapper.Map(e));
            return result;
        }


    }
}