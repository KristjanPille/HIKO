using System.Collections.Generic;
using System.Linq;
using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.carwash.kristjan.BLL.Base.Services;

namespace BLL.App.Services
{
    public class CompanyService : BaseEntityService<IAppUnitOfWork, ICompanyRepository, ICompanyServiceMapper,
        Company, DTO.Company>, ICompanyService
    {
        public CompanyService(IAppUnitOfWork uow) : base(uow, uow.Companies,
            new CompanyServiceMapper())
        {
            
        }
    }
}