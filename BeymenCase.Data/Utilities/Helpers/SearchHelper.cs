using BeymenCase.Core.Models.DataModels;

namespace BeymenCase.Data.Utilities.Helpers
{
    public static class SearchHelper
    {
        public static IQueryable<Setting> Search(this IQueryable<Setting> query, string name, string type, string value)
        {

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => (x.Name.ToLower() ?? "").Contains(name.ToLower()));

           if (!string.IsNullOrEmpty(type))
                query = query.Where(x => (x.Type.ToLower() ?? "").Contains(type.ToLower()));

          if (!string.IsNullOrEmpty(value))
                query = query.Where(x => (x.Value.ToLower() ?? "").Contains(value.ToLower()));

            return query;
        }
    }
}