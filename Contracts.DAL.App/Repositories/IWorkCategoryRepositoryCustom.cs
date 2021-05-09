using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IWorkCategoryRepositoryCustom: IWorkCategoryRepositoryCustom<WorkCategory>
    {
    }

    public interface IWorkCategoryRepositoryCustom<TCompany>
    {
    }
}