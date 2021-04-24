using AutoMapper;
using DAL.App.DTO;
using ee.itcollege.carwash.kristjan.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BLLMapper<TLeftObject, TRightObject> : BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public BLLMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<BodyPostures, DTO.BodyPostures>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Posture1, act => act.MapFrom(src => src.Posture1))
                    .ForMember(dest => dest.Posture2, act => act.MapFrom(src => src.Posture2))
                    .ForMember(dest => dest.Posture3, act => act.MapFrom(src => src.Posture3))
                    .ForMember(dest => dest.Posture4, act => act.MapFrom(src => src.Posture4))
                    .ForMember(dest => dest.Posture5, act => act.MapFrom(src => src.Posture5))
                    .ForMember(dest => dest.Posture6, act => act.MapFrom(src => src.Posture6))
                    .ForMember(dest => dest.Posture7, act => act.MapFrom(src => src.Posture7))
                    .ForMember(dest => dest.Posture8, act => act.MapFrom(src => src.Posture8))
                    .ForMember(dest => dest.Posture9, act => act.MapFrom(src => src.Posture9))
                    .ForMember(dest => dest.Posture10, act => act.MapFrom(src => src.Posture10));

            MapperConfigurationExpression.CreateMap<Additional, DTO.Additional>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Additional1, act => act.MapFrom(src => src.Additional1))
                    .ForMember(dest => dest.Additional2, act => act.MapFrom(src => src.Additional2))
                    .ForMember(dest => dest.Additional3, act => act.MapFrom(src => src.Additional3))
                    .ForMember(dest => dest.Additional4, act => act.MapFrom(src => src.Additional4))
                    .ForMember(dest => dest.Additional5, act => act.MapFrom(src => src.Additional5))
                    .ForMember(dest => dest.Additional6, act => act.MapFrom(src => src.Additional6))
                    .ForMember(dest => dest.Additional7, act => act.MapFrom(src => src.Additional7))
                    .ForMember(dest => dest.Additional8, act => act.MapFrom(src => src.Additional8));

            MapperConfigurationExpression.CreateMap<WorkingConditions, DTO.WorkingConditions>().ReverseMap()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Clothes, act => act.MapFrom(src => src.Clothes))
                    .ForMember(dest => dest.DifficultiesHolding, act => act.MapFrom(src => src.DifficultiesHolding))
                    .ForMember(dest => dest.ForceHindered, act => act.MapFrom(src => src.ForceHindered))
                    .ForMember(dest => dest.ForceRestricted, act => act.MapFrom(src => src.ForceRestricted))
                    .ForMember(dest => dest.AdverseAmbientConditions, act => act.MapFrom(src => src.AdverseAmbientConditions))
                    .ForMember(dest => dest.PositionMovementFrequent, act => act.MapFrom(src => src.PositionMovementFrequent))
                    .ForMember(dest => dest.PositionMovementOccasional, act => act.MapFrom(src => src.PositionMovementOccasional))
                    .ForMember(dest => dest.SignificantDifficultiesHolding, act => act.MapFrom(src => src.SignificantDifficultiesHolding))
                    .ForMember(dest => dest.SpatialConditionsRestricted, act => act.MapFrom(src => src.SpatialConditionsRestricted))
                    .ForMember(dest => dest.SpatialConditionsUnfavourable, act => act.MapFrom(src => src.SpatialConditionsUnfavourable));

            MapperConfigurationExpression.CreateMap<Form, DTO.Form>().ReverseMap()
                .ForMember(dest => dest.AppUser, act => act.MapFrom(src => src.AppUser))
                .ForMember(dest => dest.BodyPostures, act => act.MapFrom(src => src.BodyPostures))
                .ForMember(dest => dest.Additional, act => act.MapFrom(src => src.Additional))
                .ForMember(dest => dest.WorkingConditions, act => act.MapFrom(src => src.WorkingConditions));
            
            
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.BodyPostures, DAL.App.DTO.BodyPostures>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.BodyPostures, DAL.App.DTO.BodyPostures>();

            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Additional, DAL.App.DTO.Additional>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Additional, DAL.App.DTO.Additional>();
            
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.WorkingConditions, DAL.App.DTO.WorkingConditions>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.WorkingConditions, DAL.App.DTO.WorkingConditions>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, BLL.App.DTO.Identity.AppUser>();


            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}