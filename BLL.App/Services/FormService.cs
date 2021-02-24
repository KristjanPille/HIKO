using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.carwash.kristjan.BLL.Base.Services;
using Form = BLL.App.DTO.Form;

namespace BLL.App.Services
{
    public class FormService : BaseEntityService<IAppUnitOfWork, IFormRepository, IFormServiceMapper,
        DAL.App.DTO.Form, BLL.App.DTO.Form>, IFormService
    {
        public FormService(IAppUnitOfWork uow) : base(uow, uow.Forms,
            new FormServiceMapper())
        {
        }
    }
}