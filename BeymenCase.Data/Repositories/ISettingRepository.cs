using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using SahaBT.Retro.Data.Repositories;

namespace BeymenCase.Data.Repositories
{
    public interface ISettingRepository : IGenericRepository<Setting>
    {
        Task<PagedResult<Setting>> GetSettings(int page, int pageSize,string applicationName, string? name, string? type, string? value);
        Task<Setting> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}