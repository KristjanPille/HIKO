using System;
using System.Collections.Generic;
using ee.itcollege.carwash.kristjan.Domain.Base;

namespace Domain.App
{
    public class WorkCategory: DomainEntityIdMetadata
    {
        public string Name { get; set; } = default!;
        
        public double AverageScore { get; set; }
        
        public Guid CompanyId { get; set; }
        
        public Company? Company { get; set; }
        
        public ICollection<Form> Forms { get; set; }
    }
}