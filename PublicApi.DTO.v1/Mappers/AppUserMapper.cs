using AutoMapper;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1.Mappers
{
    public class AppUserMapper : BaseMapper<BLL.App.DTO.Identity.AppUser, AppUser>
    {
         public AppUserMapper()
        {
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Form, Form>().ReverseMap();

            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
    
}