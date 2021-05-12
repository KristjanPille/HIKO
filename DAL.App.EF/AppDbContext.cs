using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.App;
using ee.itcollege.carwash.kristjan.Contracts.DAL.Base;
using ee.itcollege.carwash.kristjan.Contracts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using AppRole = Domain.App.Identity.AppRole;
using AppUser = Domain.App.Identity.AppUser;
using BodyPostures = Domain.App.BodyPostures;
using Additional = Domain.App.Additional;
using WorkingConditions = Domain.App.WorkingConditions;
using Form = Domain.App.Form;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IBaseEntityTracker
    {
        private readonly IUserNameProvider _userNameProvider;

        public DbSet<Form> Forms { get; set; } = default!;
        public DbSet<WorkingConditions> WorkingConditions { get; set; } = default!;
        public DbSet<BodyPostures> BodyPostures { get; set; } = default!;
        public DbSet<Additional> Additionals { get; set; } = default!;
        
        public DbSet<Company> Companies { get; set; } = default!;
        
        public DbSet<WorkCategory> WorkCategories { get; set; } = default!;

        private readonly Dictionary<IDomainEntityId<Guid>, IDomainEntityId<Guid>> _entityTracker =
            new Dictionary<IDomainEntityId<Guid>, IDomainEntityId<Guid>>();

        public AppDbContext(DbContextOptions<AppDbContext> options, IUserNameProvider userNameProvider) : base(options)
        {
            _userNameProvider = userNameProvider;
        }

        public void AddToEntityTracker(IDomainEntityId<Guid> internalEntity, IDomainEntityId<Guid> externalEntity)
        {
            _entityTracker.Add(internalEntity, externalEntity);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var IntValueConverter = new IntListToStringValueConverter();

            var valueComparer = new ValueComparer<IEnumerable<int>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());
            
     
            
            // disable cascade delete
            foreach (var relationship in builder.Model
                .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
            
        }

        private void SaveChangesMetadataUpdate()
        {
            // update the state of ef tracked objects
            ChangeTracker.DetectChanges();

            var markedAsAdded = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entityEntry in markedAsAdded)
            {
                if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;

                entityWithMetaData.CreatedAt = DateTime.Now;
                entityWithMetaData.CreatedBy = _userNameProvider.CurrentUserName;
                entityWithMetaData.ChangedAt = entityWithMetaData.CreatedAt;
                entityWithMetaData.ChangedBy = entityWithMetaData.CreatedBy;
            }

            var markedAsModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entityEntry in markedAsModified)
            {
                // check for IDomainEntityMetadata
                if (!(entityEntry.Entity is IDomainEntityMetadata entityWithMetaData)) continue;

                entityWithMetaData.ChangedAt = DateTime.Now;
                entityWithMetaData.ChangedBy = _userNameProvider.CurrentUserName;

                // do not let changes on these properties get into generated db sentences - db keeps old values
                entityEntry.Property(nameof(entityWithMetaData.CreatedAt)).IsModified = false;
                entityEntry.Property(nameof(entityWithMetaData.CreatedBy)).IsModified = false;
            }
        }

        private void UpdateTrackedEntities()
        {
            foreach (var (key, value) in _entityTracker)
            {
                value.Id = key.Id;
            }
        }

        public override int SaveChanges()
        {
            SaveChangesMetadataUpdate();
            var result = base.SaveChanges();
            UpdateTrackedEntities();
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SaveChangesMetadataUpdate();
            var result = base.SaveChangesAsync(cancellationToken);
            UpdateTrackedEntities();
            return result;
        }
        
        public class IntListToStringValueConverter : ValueConverter<IEnumerable<int>, string>
        {
            public IntListToStringValueConverter() : base(le => ListToString(le), (s => StringToList(s)))
            {

            }
            public static string ListToString(IEnumerable<int> value)
            {
                if (value == null || value.Count() == 0)
                {
                    return null;
                }

                return string.Join(", ", value.Select(o => o.ToString()));
            }

            public static IEnumerable<int> StringToList(string value)
            {  
                if (value==null || value==string.Empty)
                {
                    return null;
                }

                return value.Split(',').Select(i => Convert.ToInt32(i)); ;
            }
        }
    }
}