using Domain.App.Identity;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class WorkingConditions : DomainEntityIdMetadataUser<AppUser>
    {
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