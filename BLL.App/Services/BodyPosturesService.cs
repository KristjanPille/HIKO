using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.carwash.kristjan.BLL.Base.Services;

namespace BLL.App.Services
{
    public class BodyPosturesService : BaseEntityService<IAppUnitOfWork, IBodyPosturesRepository, IBodyPosturesServiceMapper,
        BodyPostures, DTO.BodyPostures>, IBodyPosturesService
    {
        public BodyPosturesService(IAppUnitOfWork uow) : base(uow, uow.BodyPostures,
            new BodyPosturesServiceMapper())
        {
            
        }

    }
}