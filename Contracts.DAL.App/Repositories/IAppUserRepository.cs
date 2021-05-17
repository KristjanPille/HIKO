using DAL.App.DTO;
using DAL.App.DTO.Identity;
using ee.itcollege.carwash.kristjan.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IAppUserRepository : IBaseRepository<AppUser>, IAppUserRepositoryCustom
    {
    }
}