#nullable enable
using System;
using Domain.App.Identity;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class Form : DomainEntityIdMetadataUser<AppUser>
    {
        public DateTime DateAndTime { get; set; } = default!;
        
        public string? Workplace { get; set; }
        
        public int WorkingDayDuration { get; set; }
        
        public int SubActivityDuration { get; set; }
        
        public string? Evaluator { get; set; }

        public string Sex { get; set; } = default!;
        
        public int Frequency { get; set; } = default!;
        
        public int LoadWeight { get; set; } = default!;
        
        public int LoadHandlingConditions { get; set; } = default!;

        public int BodyPosture { get; set; } = default!;
        
        public int? AdditionalPoints  { get; set; }
        
        public int? IRP { get; set; }

        public int TemporalDistribution { get; set; } = default!;
        
        public int? TotalPoints { get; set; }
    }
}