﻿using Contracts.DAL.App.Repositories;
using ee.itcollege.carwash.kristjan.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork, IBaseEntityTracker
    {
        IFormRepository Forms { get; }
        IAppUserRepository AppUsers { get; }
        IAdditionalRepository Additionals { get; }
        IBodyPosturesRepository BodyPostures { get; }
        IWorkingConditionsRepository WorkingConditions { get; }
        ICompanyRepository Companies { get; }
        IWorkCategoryRepository WorkCategories { get; }
    }
}