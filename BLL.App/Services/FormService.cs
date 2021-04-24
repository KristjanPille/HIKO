using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.carwash.kristjan.BLL.Base.Services;

namespace BLL.App.Services
{
    public class FormService : BaseEntityService<IAppUnitOfWork, IFormRepository, IFormServiceMapper,
        Form, DTO.Form>, IFormService
    {
        public FormService(IAppUnitOfWork uow) : base(uow, uow.Forms, new FormServiceMapper())
        {

        }
        private readonly FormServiceMapper _mapper = new FormServiceMapper();
        
        public DTO.Form CalculateFormResult(DTO.Form form)
        {
            form.LoadWeightPoints = form.Sex switch
            {
                "men" => form.LoadWeight switch
                {
                    1 => 4,
                    2 => 6,
                    3 => 8,
                    4 => 11,
                    5 => 15,
                    6 => 25,
                    7 => 35,
                    8 => 75,
                    9 => 100,
                    _ => form.LoadWeightPoints
                },
                "women" => form.LoadWeight switch
                {
                    0 => 6,
                    1 => 9,
                    2 => 12,
                    3 => 25,
                    4 => 75,
                    5 => 85,
                    6 => 100,
                    7 => 100,
                    8 => 100,
                    9 => 100,
                    _ => form.LoadWeightPoints
                },
                _ => form.LoadWeightPoints
            };

            form.FrequencyPoints = form.Frequency switch
            {
                20 => 1.5,
                50 => 2.0,
                100 => 2.5,
                150 => 3,
                220 => 3.5,
                300 => 4,
                500 => 5,
                750 => 6,
                1000 => 7,
                1500 => 8,
                2000 => 9,
                2500 => 10,
                _ => form.FrequencyPoints
            };

            form.BodyPosturePoints += form.BodyPostures.Posture1;
            form.BodyPosturePoints += form.BodyPostures.Posture2;
            form.BodyPosturePoints += form.BodyPostures.Posture3;
            form.BodyPosturePoints += form.BodyPostures.Posture4;
            form.BodyPosturePoints += form.BodyPostures.Posture5;
            form.BodyPosturePoints += form.BodyPostures.Posture6;
            form.BodyPosturePoints += form.BodyPostures.Posture7;
            form.BodyPosturePoints += form.BodyPostures.Posture8;
            form.BodyPosturePoints += form.BodyPostures.Posture9;
            form.BodyPosturePoints += form.BodyPostures.Posture10;


            form.WorkingConditionsPoints += form.WorkingConditions.Clothes;
            form.WorkingConditionsPoints += form.WorkingConditions.DifficultiesHolding;
            form.WorkingConditionsPoints += form.WorkingConditions.ForceHindered;
            form.WorkingConditionsPoints += form.WorkingConditions.ForceRestricted;
            form.WorkingConditionsPoints += form.WorkingConditions.AdverseAmbientConditions;
            form.WorkingConditionsPoints += form.WorkingConditions.PositionMovementFrequent;
            form.WorkingConditionsPoints += form.WorkingConditions.PositionMovementOccasional;
            form.WorkingConditionsPoints += form.WorkingConditions.SignificantDifficultiesHolding;
            form.WorkingConditionsPoints += form.WorkingConditions.SpatialConditionsRestricted;
            form.WorkingConditionsPoints += form.WorkingConditions.SpatialConditionsUnfavourable;
            
            form.AdditionalPoints += form.Additional.Additional1;
            form.AdditionalPoints += form.Additional.Additional2;
            form.AdditionalPoints += form.Additional.Additional3;
            form.AdditionalPoints += form.Additional.Additional4;
            form.AdditionalPoints += form.Additional.Additional5;
            form.AdditionalPoints += form.Additional.Additional6;
            form.AdditionalPoints += form.Additional.Additional7;
            form.AdditionalPoints += form.Additional.Additional8;

            form.TotalPoints += form.BodyPosturePoints;
            form.TotalPoints += form.WorkingConditionsPoints;
            form.TotalPoints += form.AdditionalPoints;
            form.TotalPoints += form.LoadWeightPoints;
            form.TotalPoints += form.AdditionalPoints;
            form.TotalPoints += form.TemporalDistributionPoints;
            
            form.TotalPoints *= form.FrequencyPoints;

            return form;
        }
        
        public async Task<IEnumerable<DTO.Form>> GetFormsByName(string name)
        {
            var forms = await UOW.Forms.GetFormsByName(name);
            
            return forms.Select(e => _mapper.Map(e));
        }

    }
}