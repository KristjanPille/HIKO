using AutoMapper;
using ee.itcollege.carwash.kristjan.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DALMapper<TLeftObject, TRightObject> : BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public DALMapper() : base()
        { 
            // add more mappings
            MapperConfigurationExpression.CreateMap<Domain.App.Identity.AppUser, DAL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, Domain.App.Identity.AppUser>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Form, DAL.App.DTO.Form>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Form, Domain.App.Form>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Additional, DAL.App.DTO.Additional>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Additional, Domain.App.Additional>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.WorkingConditions, DAL.App.DTO.WorkingConditions>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.WorkingConditions, Domain.App.WorkingConditions>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.BodyPostures, DAL.App.DTO.BodyPostures>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.BodyPostures, Domain.App.BodyPostures>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Company, DAL.App.DTO.Company>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Company, Domain.App.Company>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.WorkCategory, DAL.App.DTO.WorkCategory>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.WorkCategory, Domain.App.WorkCategory>();

            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}