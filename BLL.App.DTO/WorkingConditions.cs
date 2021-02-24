using System;
using BLL.App.DTO.Identity;
using ee.itcollege.carwash.kristjan.Contracts.Domain;

namespace BLL.App.DTO
{
    public class WorkingConditions : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        
        public AppUser? AppUser { get; set; }
        
        public bool PositionMovementOccasional { get; set; }
        
        public bool PositionMovementFrequent { get; set; }
        
        public bool ForceRestricted { get; set; }
        
        public bool ForceHindered { get; set; }
        
        public bool AdverseAmbientConditions { get; set; }
        
        public bool SpatialConditionsRestricted { get; set; }
        
        public bool SpatialConditionsUnfavourable { get; set; }
        
        public bool Clothes { get; set; }
        
        public bool DifficultiesHolding { get; set; }
        
        public bool SignificantDifficultiesHolding { get; set; }
        
        public int? TotalPoints { get; set; }
    }
}