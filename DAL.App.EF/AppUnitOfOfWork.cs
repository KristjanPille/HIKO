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
    }
}