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
            

            MapperConfigurationExpression.CreateMap<DAL.App.DTO.WorkCategory, BLL.App.DTO.WorkCategory>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.WorkCategory, DAL.App.DTO.WorkCategory>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Additional, BLL.App.DTO.Additional>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Additional, DAL.App.DTO.Additional>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Form, BLL.App.DTO.Form>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Form, DAL.App.DTO.Form>();

            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Company, BLL.App.DTO.Company>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Company, DAL.App.DTO.Company>();

            MapperConfigurationExpression.CreateMap<DAL.App.DTO.BodyPostures, BLL.App.DTO.BodyPostures>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.BodyPostures, DAL.App.DTO.BodyPostures>();

            MapperConfigurationExpression.CreateMap<DAL.App.DTO.WorkingConditions, BLL.App.DTO.WorkingConditions>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.WorkingConditions, DAL.App.DTO.WorkingConditions>();

            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, BLL.App.DTO.Identity.AppUser>();


            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}