using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Domain.Common.Extensions;

public static class ExtensionMethods
{
    public static async Task<Pagination<T>> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize) where T : class
    {
        var pagination = new Pagination<T>
        {
            PaginationDetails = new PaginationDetails
            {
                TotalItems = query.Count(),
                PageSize = pageSize,
                CurrentPage = pageNumber
            }
        };
        if (pagination.PaginationDetails.TotalItems > 0)
            pagination.Result = await query
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        return pagination;
    }


    public static string ToUniformedPath(this string path)
    {
        return path.Replace("\\", "/");
    }

}