using System.Linq;
using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.DTO.Identity;
using ee.itcollege.carwash.kristjan.BLL.Base.Services;

namespace BLL.App.Services
{
    public class AppUserService : BaseEntityService<IAppUnitOfWork, IAppUserRepository, IAppUserServiceMapper,
        AppUser, DTO.Identity.AppUser>, IAppUserService
    {
        public AppUserService(IAppUnitOfWork uow) : base(uow, uow.AppUsers,
            new AppUserServiceMapper())
        {
            
        }

    }
}