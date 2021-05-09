using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ICompanyRepositoryCustom: ICompanyRepositoryCustom<Company>
    {
    }

    public interface ICompanyRepositoryCustom<TCompany>
    {
    }
}