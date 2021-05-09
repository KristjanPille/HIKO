using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using carwash.kristjan.Contracts.Domain;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class Company: IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        
        public string Name { get; set; } = default!;
        
        public bool IsFinished { get; set; }
        
        public int RegisterCode { get; set; } = default!;
        
        public ICollection<WorkCategory>? WorkCategories { get; set; }
    }
}