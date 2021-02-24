using Domain.App.Identity;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class WorkingConditions : DomainEntityIdMetadataUser<AppUser>
    {
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