using Microsoft.EntityFrameworkCore;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Data.Common.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplySoftDeleteQueryFilters(this ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                entityType.AddSoftDeleteQueryFilter();
            }

        }
    }
    
    public static void RestrictForeignKeyDelete(this ModelBuilder builder)
    {
        var foreignKeyRelationships = builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var fkRelationship in foreignKeyRelationships)
        {
            fkRelationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}