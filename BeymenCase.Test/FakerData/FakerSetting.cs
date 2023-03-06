using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Models.Dtos.Setting;

namespace BeymenCase.Test.FakerData
{
    public class FakerSetting
    {
        public FakerSetting()
        {
            SetFakeSettingInitializer();
        }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public Setting Setting { get; set; }
        public List<Setting> Settings { get; set; }
        public PagedResult<SettingDto> PagedSettingDto { get; set; }
        public PagedResult<Setting> PagedSetting { get; set; }
        public SettingCreateDto CreateDto { get; set; }
        public SettingUpdateDto UpdateDto { get; set; }
        private void SetFakeSettingInitializer()
        {
            var settings = FakerBuilder.GetFakerSettings();

            Setting = settings.FirstOrDefault();
            Settings = settings.ToList();
            CreateDto = FakerBuilder.GetFakerSettingCreateDto();
            UpdateDto = FakerBuilder.GetFakerSettingUpdateDto();
            PagedSettingDto = FakerBuilder.GetFakerPagedSettingDto();
            PagedSetting = FakerBuilder.GetFakerPagedSetting();
        }
    }
}