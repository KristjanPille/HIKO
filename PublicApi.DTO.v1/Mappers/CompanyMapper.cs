using AutoMapper;

namespace PublicApi.DTO.v1.Mappers
{
    public class CompanyMapper : BaseMapper<BLL.App.DTO.Company, Company>
    {
        public CompanyMapper()
        {
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Form, Form>().ReverseMap()
                .ForMember(dest => dest.AppUser, act => act.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.BodyPostures, act => act.MapFrom(src => src.BodyPostures))
                .ForMember(dest => dest.Additional, act => act.MapFrom(src => src.Additional))
                .ForMember(dest => dest.WorkingConditions, act => act.MapFrom(src => src.WorkingConditions));
            
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.WorkCategory, WorkCategory>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.CompanyId, act => act.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.Forms, act => act.MapFrom(src => src.Forms))
                .ForMember(dest => dest.AverageScore, act => act.MapFrom(src => src.AverageScore));
            
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Company, Company>().ReverseMap()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.RegisterCode, act => act.MapFrom(src => src.RegisterCode))
                .ForMember(dest => dest.WorkCategories, act => act.MapFrom(src => src.WorkCategories))
                .ForMember(dest => dest.AppUserId, act => act.MapFrom(src => src.AppUserId));
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}