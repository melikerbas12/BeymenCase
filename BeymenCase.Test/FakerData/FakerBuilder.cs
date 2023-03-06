using BeymenCase.Core.Models;
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

        public static SettingUpdateDto GetFakerSettingUpdateDto()
        {
            return new SettingUpdateDto()
            {
                Id = 1,
                Name = "SiteName",
                Type = "String",
                Value = "Boyner.com.tr",
                ApplicationName = "SERVICE-A",
                IsActive = false
            };
        }

        public static PagedResult<SettingDto> GetFakerPagedSettingDto()
        {
            var list = new PagedResult<SettingDto>();
            list.CurrentPage = 0;
            list.PageCount = 0;
            list.PageSize = 0;
            list.RowCount = 0;
            list.Results.Add(new SettingDto() { Id = 1, Name = "SiteName", Type = "String", Value = "Boyner.com.tr", IsActive = true, ApplicationName = "SERVICE-A" });
            list.Results.Add(new SettingDto() { Id = 2, Name = "IsBasketEnabled", Type = "Boolean", Value = "1", IsActive = true, ApplicationName = "SERVICE-B" });
            return list;
        }
        
        public static PagedResult<Setting> GetFakerPagedSetting()
        {
            var list = new PagedResult<Setting>();
            list.CurrentPage = 0;
            list.PageCount = 0;
            list.PageSize = 0;
            list.RowCount = 0;
            list.Results.Add(new Setting() { Id = 1, Name = "SiteName", Type = "String", Value = "Boyner.com.tr", IsActive = true, ApplicationName = "SERVICE-A" });
            list.Results.Add(new Setting() { Id = 2, Name = "IsBasketEnabled", Type = "Boolean", Value = "1", IsActive = true, ApplicationName = "SERVICE-B" });
            return list;
        }
    }
}