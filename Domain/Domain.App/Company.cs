using System.Collections;
using System.Collections.Generic;
using Domain.App.Identity;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class Company : DomainEntityIdMetadataUser<AppUser>
    {
        public string Name { get; set; } = default!;
        
        public int RegisterCode { get; set; } = default!;
        
        public bool IsFinished { get; set; }

        public ICollection<WorkCategory> WorkCategories { get; set; }
    }
}