using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Models.Dtos.Setting;

using Mapster;

namespace BeymenCase.Core.Contracts
{
    public static class SettingContract
    {
        public static TypeAdapterConfig SettingConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<Setting, SettingDto>();
            return config;
        }
        public static PagedResult<SettingDto> Contract(this PagedResult<Setting> source)
        {
            var config = SettingConfig();
            return source.Adapt<PagedResult<SettingDto>>(config);
        }
        public static SettingDto Contract(this Setting source)
        {
            var config = SettingConfig();
            return source.Adapt<SettingDto>(config);
        }
        public static Setting Contract(this SettingDto source)
        {
            var config = SettingConfig();
            return source.Adapt<Setting>(config);
        }

        public static Setting Contract(this SettingCreateDto source)
        {
            return source.Adapt<Setting>();
        }
    }
}
