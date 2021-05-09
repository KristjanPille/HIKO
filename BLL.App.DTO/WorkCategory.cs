using System;
using System.Collections.Generic;
using ee.itcollege.carwash.kristjan.Contracts.Domain;

namespace BLL.App.DTO
{
    public class WorkCategory : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = default!;
        
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        
        public double AverageScore { get; set; }
        
        public ICollection<Form> Forms { get; set; }
    }
}