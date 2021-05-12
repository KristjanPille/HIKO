using System;
using System.Collections.Generic;
using ee.itcollege.carwash.kristjan.Contracts.Domain;

namespace BLL.App.DTO
{
    public class LangStr : IDomainEntityId
    {
        public Guid Id { get; set; }

        public ICollection<LangStrTranslation>? Translations { get; set; }
    }
}