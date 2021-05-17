using AutoMapper;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace BLL.App.Mappers
{
    public class AppUserServiceMapper : BLLMapper<DALAppDTO.Identity.AppUser, BLLAppDTO.Identity.AppUser>, IAppUserServiceMapper
    {
        public AppUserServiceMapper()
        {
            MapperConfigurationExpression.CreateMap<DALAppDTO.Form, BLLAppDTO.Form>().ReverseMap();;

            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}