#nullable enable
using System;
using System.Collections.Generic;
using Domain.App.Identity;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class Form : DomainEntityIdMetadataUser<AppUser>
    {
        public DateTime FormCreatedDate { get; set; } = default!;
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string? Workplace { get; set; }
        
        public string? SubActivity { get; set; }
        
        public double WorkingDayDuration { get; set; }
        
        public double SubActivityDuration { get; set; }
        
        public string? Evaluator { get; set; }

        public string Sex { get; set; } = default!;
        
        public double Frequency { get; set; } = default!;
        public double FrequencyPoints { get; set; } = 1;
        
        public double LoadWeight { get; set; } = default!;
        public double LoadWeightPoints { get; set; } = 0;
        
        public double LoadHandlingConditions { get; set; } = default!;

        public BodyPostures? BodyPostures { get; set; }
        public Guid? BodyPosturesId { get; set; }
        public double BodyPosturePoints { get; set; } = 0;

        public Additional? Additional { get; set; }
        public Guid? AdditionalId { get; set; }
        public double AdditionalPoints { get; set; } = 0;

        public WorkingConditions? WorkingConditions { get; set; }
        public Guid? WorkingConditionsId { get; set; }
        public double WorkingConditionsPoints { get; set; } = 0;
        
        public int TemporalDistributionPoints { get; set; }
        
        public double TotalPoints { get; set; } = 0;
    }
}