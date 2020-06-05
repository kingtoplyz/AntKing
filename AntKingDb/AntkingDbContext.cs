using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AntKingDb.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AntKingDb
{
    public class AntkingDbContext : DbContext
    {
        public AntkingDbContext(DbContextOptions options)
               : base(options)
        {
        }
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public Int32 SaveChanges(String userCode)
        {
            ApplyCreateUpdateMetadata(userCode); 
            return SaveChanges();
        }

        public Int32 SaveChanges(String userCode, Boolean acceptAllChangesOnSuccess)
        {
            ApplyCreateUpdateMetadata(userCode);

            return SaveChanges(acceptAllChangesOnSuccess);
        }

        public Task<Int32> SaveChangesAsync(String userCode, CancellationToken cancellationToken = default)
        {
            ApplyCreateUpdateMetadata(userCode);

            return SaveChangesAsync(cancellationToken);
        }

        public Task<Int32> SaveChangesAsync(String userCode, Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyCreateUpdateMetadata(userCode);

            return SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private new Int32 SaveChanges()
        {
            return base.SaveChanges();
        }

        private new Int32 SaveChanges(Boolean acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private new Task<Int32> SaveChangesAsync(Boolean acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private new Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyCreateUpdateMetadata(String userCode)
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                BaseEntity entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        entity.UpdateBy = userCode;
                        entity.UpdateTimestamp = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Added)
                    {
                        entity.CreateBy = userCode;
                        entity.UpdateBy = userCode;
                        entity.CreateTimestamp = DateTime.Now;
                        entity.UpdateTimestamp = DateTime.Now;
                    }
                }
            }
        }
    }
}
