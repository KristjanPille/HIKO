using System;
using System.Text.Json.Serialization;
using DAL.App.DTO.Identity;
using ee.itcollege.carwash.kristjan.Contracts.Domain;

namespace DAL.App.DTO
{
    public class Additional : IDomainEntityId
    {
        public Guid Id { get; set; }

        public Guid AppUserId { get; set; }
        
        [JsonIgnore]
        public AppUser? AppUser { get; set; }

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