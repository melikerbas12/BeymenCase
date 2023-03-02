using Microsoft.EntityFrameworkCore;
using BeymenCase.Core.Models;

namespace BeymenCase.Data
{
     public static class PagedHelper
    {
        public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.CountAsync().Result
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }

        public static void SetBaseData<T,E>(PagedResult<T> source, PagedResult<E> target)
        {
            target.CurrentPage = source.CurrentPage;
            target.PageSize = source.PageSize;
            target.RowCount = source.RowCount;
            target.PageCount = source.PageCount;
        }
    }
}
