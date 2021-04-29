using System;
using System.Text.Json.Serialization;
using ee.itcollege.carwash.kristjan.Contracts.Domain;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class Form : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        
        [JsonIgnore]
        public AppUser? AppUser { get; set; }

        public DateTime FormCreatedDate { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
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
        
        public double LoadHandlingConditions { get; set; } = 0;

        public BodyPostures BodyPostures { get; set; } = default!;
        public Guid? BodyPosturesId { get; set; }
        public double BodyPosturePoints { get; set; } = 0;

        public Additional Additional { get; set; } = default!;
        public Guid? AdditionalId { get; set; }
        public double AdditionalPoints { get; set; } = 0;

        public WorkingConditions WorkingConditions { get; set; } = default!;
        public Guid? WorkingConditionsId { get; set; }
        public double WorkingConditionsPoints { get; set; } = 0;
        
        public double TemporalDistributionPoints { get; set; } = 0;
        
        public double TotalPoints { get; set; } = 0;
    }

}