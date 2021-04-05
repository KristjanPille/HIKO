using Domain.App.Identity;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class BodyPostures : DomainEntityIdMetadataUser<AppUser>
    {
        public int Posture1 { get; set; }
        
        public int Posture2 { get; set; }
        
        public int Posture3 { get; set; }
        
        public int Posture4 { get; set; }
        
        public int Posture5 { get; set; }
        
        public int Posture6 { get; set; }
        
        public int Posture7 { get; set; }
        
        public int Posture8 { get; set; }
        
        public int Posture9 { get; set; }
        
        public int Posture10 { get; set; }
    }
}