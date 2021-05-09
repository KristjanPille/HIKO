using System;
using System.Collections.Generic;
using DAL.App.DTO.Identity;
using ee.itcollege.carwash.kristjan.Contracts.Domain;

namespace DAL.App.DTO
{
    public class Company: IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        
        public AppUser? AppUser { get; set; }
        
        public string Name { get; set; } = default!;
        
        public bool IsFinished { get; set; }
        
        public int RegisterCode { get; set; } = default!;
        
        public ICollection<WorkCategory>? WorkCategories { get; set; }
    }
}