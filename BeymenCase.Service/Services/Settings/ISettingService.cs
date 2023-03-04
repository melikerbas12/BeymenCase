
using BeymenCase.Core.Models;
using BeymenCase.Core.Models.Dtos.Setting;

namespace BeymenCase.Service.Services
{
    public interface ISettingService
    {

        Task<PagedResult<SettingDto>> GetSettings(int page, int pageSize,string applicationName, string? name, string? type, string? value);
        Task<SettingDto> GetById(int id, CancellationToken cancellationToken);
        Task<BoolRef> Create(SettingCreateDto model, CancellationToken cancellationToken);
        Task<BoolRef> Update(SettingUpdateDto model, CancellationToken cancellationToken);
        Task<BoolRef> Delete(int id, CancellationToken cancellationToken);
    }
}