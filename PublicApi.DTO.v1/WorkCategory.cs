using System;
using System.Collections.Generic;
using carwash.kristjan.Contracts.Domain;

namespace PublicApi.DTO.v1
{
    public class WorkCategory : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = default!;
        
        public Guid CompanyId { get; set; }
        
        public double AverageScore { get; set; }
        
        public ICollection<Form> Forms { get; set; }
    }
}