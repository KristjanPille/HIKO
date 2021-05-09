using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class CompanyServiceMapper : BLLMapper<DALAppDTO.Company, BLLAppDTO.Company>, ICompanyServiceMapper
    {
        
    }
}