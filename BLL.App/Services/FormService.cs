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

        public Form CalculateFormResult(Form form)
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

            if (form.WorkingConditions.PositionMovementOccasional)
            {
                form.TotalPoints += 1;
            }
            if (form.WorkingConditions.PositionMovementFrequent)
            {
                form.TotalPoints += 2;
            }
            if (form.WorkingConditions.ForceRestricted)
            {
                form.TotalPoints += 1;
            } 
            if (form.WorkingConditions.ForceHindered)
            {
                form.TotalPoints += 2;
            }   
            if (form.WorkingConditions.AdverseAmbientConditions)
            {
                form.TotalPoints += 1;
            }
            if (form.WorkingConditions.SpatialConditionsRestricted)
            {
                form.TotalPoints += 1;
            }
            if (form.WorkingConditions.SpatialConditionsUnfavourable)
            {
                form.TotalPoints += 2;
            }
            if (form.WorkingConditions.Clothes)
            {
                form.TotalPoints += 1;
            }
            if (form.WorkingConditions.DifficultiesHolding)
            {
                form.TotalPoints += 2;
            }
            if (form.WorkingConditions.SignificantDifficultiesHolding)
            {
                form.TotalPoints += 5;
            }

            form.TotalPoints += form.BodyPostures.Sum();
            form.TotalPoints += form.Additional.Sum();
            form.TotalPoints += form.LoadWeightPoints;
            form.TotalPoints += form.AdditionalPoints;
            form.TotalPoints += form.TemporalDistributionPoints;
            
            form.TotalPoints *= form.FrequencyPoints;

            return form;
        }
    }
}