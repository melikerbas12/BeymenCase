using BeymenCase.Core.Models.DataModels;

namespace BeymenCase.ConfLib.Repositories
{
    public interface IConfigurationRepository
    {
          Task<Setting> GetByApplicationName(string applicationName, string key);
          Task<IList<Setting>> Get(string applicationName);
    }
}