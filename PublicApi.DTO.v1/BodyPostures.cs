using System;
using carwash.kristjan.Contracts.Domain;

namespace PublicApi.DTO.v1
{
    public class BodyPostures : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public Guid AppUserId { get; set; }
        
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