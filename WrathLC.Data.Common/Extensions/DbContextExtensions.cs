using Microsoft.EntityFrameworkCore;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Data.Common.Extensions;

public static class DbContextExtensions
{
    public static void ProcessCustomInterfaces(this DbContext dbContext)
    {
        var autoDetectChangesEnabled = dbContext.ChangeTracker.AutoDetectChangesEnabled;
        try
        {
            dbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            foreach (var entry in dbContext.ChangeTracker.Entries())
            {
                #region Configure ISoftDelete Fields
                if (entry.Entity is ISoftDelete deleted)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            deleted.IsDeleted = false;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            deleted.IsDeleted = true;
                            deleted.DeletedAt = DateTime.UtcNow;
                            break;
                    }
                }
                #endregion

                #region Configure ITracked Fields
                if (entry.Entity is ICreated created && entry.State == EntityState.Added)
                {
                    created.CreatedAt = DateTime.UtcNow;
                }
                if (entry.Entity is IUpdated updated && entry.State == EntityState.Modified)
                {
                    updated.UpdatedAt = DateTime.UtcNow;
                }
                #endregion
            }
        }
        finally
        {
            dbContext.ChangeTracker.AutoDetectChangesEnabled = autoDetectChangesEnabled;
        }
    } 
}