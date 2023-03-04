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

        public async Task<Setting> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Settings
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<PagedResult<Setting>> GetSettings(int page, int pageSize, string applicationName, string name, string type, string value)
        {
            return await _context.Settings
               .AsNoTracking()
               .Where(s => s.ApplicationName == applicationName && s.IsActive)
               .Search(name, type, value)
               .GetPaged(page, pageSize);
        }
    }
}