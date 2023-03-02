using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Data.Context;
using BeymenCase.Data.Utilities.Helpers;
using BeymenCode.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeymenCase.Data.Repositories
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(BeymenCaseDbContext context) : base(context)
        {
        }

        public Task<Setting> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<Setting>> GetSettings(int page, int pageSize, string name, string type, string value)
        {
             return await _context.Settings
                .AsNoTracking()
                .Search(name, type, value)
                .GetPaged(page, pageSize);
        }
    }
}