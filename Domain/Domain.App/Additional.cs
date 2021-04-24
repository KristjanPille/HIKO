using Domain.App.Identity;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class Additional : DomainEntityIdMetadataUser<AppUser>
    {
        public double Additional1 { get; set; }
        
        public double Additional2 { get; set; }
        
        public double Additional3 { get; set; }
        
        public double Additional4 { get; set; }
        
        public double Additional5 { get; set; }
        
        public double Additional6 { get; set; }
        
        public double Additional7 { get; set; }
        
        public double Additional8 { get; set; }
    }
}