using DAL.App.DTO;
using ee.itcollege.carwash.kristjan.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface ILangStrTranslationRepository : IBaseRepository<LangStrTranslation>, ILangStrTranslationRepositoryCustom
    {
        
    }

}