namespace BeymenCase.ConfLib.Services;
public interface IConfigurationReader
{
    Task<T> GetValue<T>(string key);
}

