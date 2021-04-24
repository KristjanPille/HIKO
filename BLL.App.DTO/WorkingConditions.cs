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
        
        public int PositionMovementOccasional { get; set; }
        
        public int PositionMovementFrequent { get; set; }
        
        public int ForceRestricted { get; set; }
        
        public int ForceHindered { get; set; }
        
        public int AdverseAmbientConditions { get; set; }
        
        public int SpatialConditionsRestricted { get; set; }
        
        public int SpatialConditionsUnfavourable { get; set; }
        
        public int Clothes { get; set; }
        
        public int DifficultiesHolding { get; set; }
        
        public int SignificantDifficultiesHolding { get; set; }
    }
}