
namespace BeymenCase.Core.Models.DataModels
{
    public class Setting: BaseIdEntityModel, IEntity
    {  
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }      
        public string ApplicationName { get; set; }
    }
}