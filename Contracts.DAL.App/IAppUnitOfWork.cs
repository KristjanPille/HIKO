using Contracts.DAL.App.Repositories;
using ee.itcollege.carwash.kristjan.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork, IBaseEntityTracker
    {
        IFormRepository Forms { get; }
        IAdditionalRepository Additionals { get; }
        IBodyPosturesRepository BodyPostures { get; }
        IWorkingConditionsRepository WorkingConditions { get; }
    }
}