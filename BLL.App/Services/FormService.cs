using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.carwash.kristjan.BLL.Base.Services;
using Form = BLL.App.DTO.Form;

namespace BLL.App.Services
{
    public class FormService : BaseEntityService<IAppUnitOfWork, IFormRepository, IFormServiceMapper,
        DAL.App.DTO.Form, BLL.App.DTO.Form>, IFormService
    {
        public FormService(IAppUnitOfWork uow) : base(uow, uow.Forms,
            new FormServiceMapper())
        {
            
        }

        public PublicApi.DTO.v1.Form CalculateFormResult(Form form)
        {
            var totalPoints = 0;
            form.LoadWeightPoints = form.Sex switch
            {
                // Do calculate magic here
                "men" => form.LoadWeight switch
                {
                    5 => 4,
                    10 => 6,
                    15 => 8,
                    20 => 11,
                    25 => 15,
                    30 => 25,
                    35 => 35,
                    40 => 75,
                    45 => 100,
                    _ => form.LoadWeightPoints
                },
                "women" => form.LoadWeight switch
                {
                    5 => 6,
                    10 => 9,
                    15 => 12,
                    20 => 25,
                    25 => 75,
                    30 => 85,
                    35 => 100,
                    40 => 100,
                    45 => 100,
                    _ => form.LoadWeightPoints
                },
                _ => form.LoadWeightPoints
            };
            totalPoints += form.LoadWeightPoints!.Value;
            totalPoints += form.LoadHandlingConditions;
            
            totalPoints += form.BodyPostures.Sum();
            form.BodyPosturePoints = form.BodyPostures.Sum();
            
            totalPoints += form.Additional!.Sum();
            form.AdditionalPoints = form.Additional!.Sum();
            
            if (form.WorkingConditions.PositionMovementOccasional)
            {
                totalPoints += 1;
            }
            if (form.WorkingConditions.PositionMovementFrequent)
            {
                totalPoints += 2;
            }
            if (form.WorkingConditions.ForceRestricted)
            {
                totalPoints += 1;
            }
            if (form.WorkingConditions.ForceHindered)
            {
                totalPoints += 2;
            }
            if (form.WorkingConditions.AdverseAmbientConditions)
            {
                totalPoints += 1;
            }
            if (form.WorkingConditions.SpatialConditionsRestricted)
            {
                totalPoints += 1;
            }
            if (form.WorkingConditions.SpatialConditionsUnfavourable)
            {
                totalPoints += 2;
            }
            if (form.WorkingConditions.Clothes)
            {
                totalPoints += 1;
            }
            if (form.WorkingConditions.DifficultiesHolding)
            {
                totalPoints += 2;
            }
            if (form.WorkingConditions.SignificantDifficultiesHolding)
            {
                totalPoints += 5;
            }

            totalPoints += form.TemporalDistributionPoints;
            throw new NotImplementedException();
        }
    }
}