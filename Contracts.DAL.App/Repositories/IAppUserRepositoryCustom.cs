using DAL.App.DTO;
using DAL.App.DTO.Identity;
using ee.itcollege.carwash.kristjan.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IAppUserRepositoryCustom: IAppUserRepositoryCustom<AppUser>
    {
    }

    public interface IAppUserRepositoryCustom<TAppUser>
    {
    }
}