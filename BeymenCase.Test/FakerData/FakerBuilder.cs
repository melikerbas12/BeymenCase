using BeymenCase.Core.Models.DataModels;
using BeymenCase.Core.Models.Dtos.Setting;

namespace BeymenCase.Test.FakerData
{
    public class FakerBuilder
    {
        public static List<Setting> GetFakerSettings()
        {
            var list = new List<Setting>();
            list.Add(new Setting() { Id = 1, Name = "SiteName", Type = "String", Value = "Boyner.com.tr", IsActive = true, ApplicationName = "SERVICE-A" });
            list.Add(new Setting() { Id = 2, Name = "IsBasketEnabled", Type = "Boolean", Value = "1", IsActive = true, ApplicationName = "SERVICE-B" });
            return list;
        }

        public static SettingCreateDto GetFakerSettingCreateDto()
        {
            return new SettingCreateDto()
            {
                Name = "SiteName",
                Type = "String",
                Value = "Boyner.com.tr",
                ApplicationName = "SERVICE-A"
            };
        }
    }
}