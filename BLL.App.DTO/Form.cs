using System;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using ee.itcollege.carwash.kristjan.Contracts.Domain;

namespace BLL.App.DTO
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
        
        public int LoadWeight { get; set; } = default!;
        
        public int LoadHandlingConditions { get; set; } = default!;

        public int BodyPosture { get; set; } = default!;
        
        public int? AdditionalPoints  { get; set; }
        
        public int? IRP { get; set; }

        public int TemporalDistribution { get; set; } = default!;
        
        public int? TotalPoints { get; set; }
    }
}