namespace BeymenCase.Core.Models.Dtos.Setting
{
    public class SettingDto: BaseIdDtoModel, IDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }      
        public string ApplicationName { get; set; }
    }
}