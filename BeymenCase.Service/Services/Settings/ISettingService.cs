
using BeymenCase.Core.Models;
using BeymenCase.Core.Models.Dtos.Setting;

namespace BeymenCase.Service.Services
{
    public interface ISettingService
    {

        Task<PagedResult<SettingDto>> GetSettings(int page, int pageSize, string name, string type, string value);
        Task<SettingDto> GetById(int id);
        Task<BoolRef> Insert(SettingCreateDto model);
        Task<BoolRef> Update(SettingUpdateDto model);
        Task<BoolRef> Delete(int id);
    }
}