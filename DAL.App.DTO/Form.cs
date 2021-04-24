using System;
using ee.itcollege.carwash.kristjan.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class Form : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        
        public AppUser? AppUser { get; set; }

        public DateTime DateAndTime { get; set; } = default!;
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Workplace { get; set; }
        
        public string? SubActivity { get; set; }
        
        public double WorkingDayDuration { get; set; }
        
        public double SubActivityDuration { get; set; }
        
        public string? Evaluator { get; set; }

        public string Sex { get; set; } = default!;
        
        public double Frequency { get; set; }
        public double FrequencyPoints { get; set; } = 1;
        
        public double LoadWeight { get; set; }
        public double LoadWeightPoints { get; set; } = 0;
        
        public double LoadHandlingConditions { get; set; }

        public BodyPostures? BodyPostures { get; set; }
        public Guid? BodyPosturesId { get; set; }
        public double BodyPosturePoints { get; set; } = 0;

        public Additional? Additional { get; set; }
        public Guid? AdditionalId { get; set; }
        public double AdditionalPoints { get; set; } = 0;

        public WorkingConditions? WorkingConditions { get; set; }
        public Guid? WorkingConditionsId { get; set; }
        public double WorkingConditionsPoints { get; set; } = 0;
        
        public double TemporalDistributionPoints { get; set; } = 0;
        
        public double TotalPoints { get; set; } = 0;
    }
}