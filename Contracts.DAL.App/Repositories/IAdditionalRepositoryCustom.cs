using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IAdditionalRepositoryCustom: IAdditionalRepositoryCustom<Additional>
    {
    }

    public interface IAdditionalRepositoryCustom<TAdditional>
    {
    }
}