﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Form = BLL.App.DTO.Form;

namespace Contracts.BLL.App.Services
{
    public interface IFormService : IBaseEntityService<Form>, IFormRepositoryCustom<Form>
    {
        Form CalculateFormResult(Form form);
        
        Task<IEnumerable<Form>> GetFormsByName(string filter);
    }
}