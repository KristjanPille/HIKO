﻿using BLL.App.DTO;
using ee.itcollege.carwash.kristjan.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IBodyPosturesService : IBaseEntityService<BodyPostures>, IFormRepositoryCustom<BodyPostures>
    {
    }
}