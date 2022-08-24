using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WrathLC.Utility.Common.DataContracts.Interfaces;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Data.Common.Extensions;

public static class QueryableExtensions
{
    public static async Task<T> SingleOrNotFoundAsync<T>(this IQueryable<T> query)
    {
        try
        {
            return await query.SingleAsync();
        }
        catch (InvalidOperationException ex)
        {
            throw new KeyNotFoundException("The requested resource could not be found.", ex);
        }
    }
    public static async Task<bool> ContainsOrNotFoundAsync<T>(this IQueryable<T> query, Expression<Func<T,bool>> predicate)
    {
            var exists =  await query.Where(predicate).AnyAsync();
            if (!exists)
            {
                throw new KeyNotFoundException("The requested resource could not be found.");
            }

            return true;
    }
    public static async Task<PagedListModel<T>> ToPagedListAsync<T>(this IQueryable<T> query, IPaginated request, int count)
    {
        return new PagedListModel<T>()
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = count,
            Items = await query.ToListAsync()
        };
    }
    
    public static IQueryable<T> Page<T>(this IOrderedEnumerable<T> query, IPaginated parameters, out int count)
    {
        return query.AsQueryable().Page(parameters, out count);
    }

    public static IEnumerable<T> Page<T>(this IEnumerable<T> query, IPaginated parameters, out int count)
        => query.AsQueryable().Page(parameters, out count);
    public static IQueryable<T> Page<T>(this IQueryable<T> query, IPaginated parameters, out int count)
    {
        if (parameters.Page < 0)
        {
            throw new ArgumentException("Invalid page. Please specify a page greater than or equal to zero.");
        }

        if (parameters.PageSize <= 0)
        {
            throw new ArgumentException("Invalid page size. Please specify a page size greater than zero.");
        }

        var size = Math.Min(parameters.PageSize, int.MaxValue);
        count = query.Count();
        return query
            .Skip(Math.Max(parameters.Page, 0) * size)
            .Take(size);
    }
}