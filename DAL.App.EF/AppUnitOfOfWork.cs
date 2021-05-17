using System;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.carwash.kristjan.DAL.Base.EF;
using DAL.App.EF.Repositories;

namespace DAL.App.EF
{
    public class AppUnitOfOfWork : EFBaseUnitOfWork<Guid, AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfOfWork(AppDbContext uowDbContext) : base(uowDbContext)
        {    
        }

        public IFormRepository Forms =>
            GetRepository<IFormRepository>(() => new FormRepository(UOWDbContext));
        
        public IAppUserRepository AppUsers =>
            GetRepository<IAppUserRepository>(() => new AppUserRepository(UOWDbContext));
        
        public IWorkingConditionsRepository WorkingConditions =>
            GetRepository<IWorkingConditionsRepository>(() => new WorkingConditionsRepository(UOWDbContext));
        
        public IAdditionalRepository Additionals =>
            GetRepository<IAdditionalRepository>(() => new AdditionalRepository(UOWDbContext));
        
        public IBodyPosturesRepository BodyPostures =>
            GetRepository<IBodyPosturesRepository>(() => new BodyPosturesRepository(UOWDbContext));
        
        public ICompanyRepository Companies =>
            GetRepository<ICompanyRepository>(() => new CompanyRepository(UOWDbContext));
        
        public IWorkCategoryRepository WorkCategories =>
            GetRepository<IWorkCategoryRepository>(() => new WorkCategoryRepository(UOWDbContext));
    }
}