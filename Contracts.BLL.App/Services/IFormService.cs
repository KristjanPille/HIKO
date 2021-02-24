﻿using System.Threading.Tasks;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Form = BLL.App.DTO.Form;

namespace Contracts.BLL.App.Services
{
    public interface IFormService : IBaseEntityService<Form>, IFormRepositoryCustom<Form>
    {
        PublicApi.DTO.v1.Form CalculateFormResult(Form form);
    }
}