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
        public Setting Setting { get; set; }
        public List<Setting> Settings { get; set; }
        public SettingCreateDto CreateDto { get; set; }
        private void SetFakeSettingInitializer()
        {
            var settings = FakerBuilder.GetFakerSettings();

            Setting = settings.FirstOrDefault();
            Settings = settings.ToList();
            CreateDto = FakerBuilder.GetFakerSettingCreateDto();
        }
    }
}