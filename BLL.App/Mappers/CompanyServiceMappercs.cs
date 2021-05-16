using AutoMapper;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class CompanyServiceMapper : BLLMapper<DALAppDTO.Company, BLLAppDTO.Company>, ICompanyServiceMapper
    {
        public CompanyServiceMapper()
        {
            MapperConfigurationExpression.CreateMap<DALAppDTO.Additional, BLLAppDTO.Additional>().ReverseMap();
            MapperConfigurationExpression.CreateMap<DALAppDTO.WorkCategory, BLLAppDTO.WorkCategory>().ReverseMap();;
            MapperConfigurationExpression.CreateMap<DALAppDTO.Form, BLLAppDTO.Form>().ReverseMap();;
            MapperConfigurationExpression.CreateMap<DALAppDTO.Identity.AppUser, BLLAppDTO.Identity.AppUser>().ReverseMap();

            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }

    }
}