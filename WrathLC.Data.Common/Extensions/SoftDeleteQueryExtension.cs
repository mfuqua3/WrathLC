using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Data.Common.Extensions;

public static class SoftDeleteQueryExtension
{
    public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityType)
    {
        var methodToCall = typeof(SoftDeleteQueryExtension)
            .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
            ?.MakeGenericMethod(entityType.ClrType);

        var filter = methodToCall?.Invoke(null, new object[] { });
        entityType.SetQueryFilter(filter as LambdaExpression);
        entityType.AddIndex(entityType.FindProperty(nameof(ISoftDelete.IsDeleted)) ?? 
                            throw new MissingMemberException("Unexpected error. Property not found."));
    }

    internal static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, ISoftDelete
    {
        Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
        return filter;
    }
}