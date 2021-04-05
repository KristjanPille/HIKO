using System;
using ee.itcollege.carwash.kristjan.Contracts.Domain;

namespace BLL.App.DTO
{
    public class Additional : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public int Additional1 { get; set; }
        
        public int Additional2 { get; set; }
        
        public int Additional3 { get; set; }
        
        public int Additional4 { get; set; }
        
        public int Additional5 { get; set; }
        
        public int Additional6 { get; set; }
        
        public int Additional7 { get; set; }
        
        public int Additional8 { get; set; }
    }
}