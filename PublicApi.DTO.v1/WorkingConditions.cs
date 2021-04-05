using System;
using carwash.kristjan.Contracts.Domain;

namespace PublicApi.DTO.v1
{
    public class WorkingConditions : IDomainEntityId
    {
        public Guid Id { get; set; }
        
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
    }
}