using System.Threading.Tasks;
using BLL.App.DTO;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO.Identity;
using AppUser = BLL.App.DTO.Identity.AppUser;

namespace Contracts.BLL.App.Services
{
    public interface IAppUserService : IBaseEntityService<AppUser>, IAppUserRepositoryCustom<AppUser>
    {
    }
}