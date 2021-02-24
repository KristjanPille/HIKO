using System;
using System.Collections.Generic;
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
        
        public string? Workplace { get; set; }
        
        public int WorkingDayDuration { get; set; }
        
        public int SubActivityDuration { get; set; }
        
        public string? Evaluator { get; set; }

        public string Sex { get; set; } = default!;
        
        public int Frequency { get; set; } = default!;
        public int? FrequencyPoints { get; set; }
        
        public int LoadWeight { get; set; } = default!;
        public int? LoadWeightPoints { get; set; }
        
        public int LoadHandlingConditions { get; set; } = default!;

        public ICollection<int> BodyPostures { get; set; } = default!;
        public int? BodyPosturePoints { get; set; } = default!;

        public ICollection<int>? Additional { get; set; }
        public int? AdditionalPoints { get; set; }
        
        public WorkingConditions WorkingConditions { get; set; } = default!;

        public string TemporalDistribution { get; set; } = default!;
        public int? TemporalDistributionPoints { get; set; }
        
        public int? TotalPoints { get; set; }
    }
}