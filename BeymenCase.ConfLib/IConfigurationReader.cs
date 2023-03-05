namespace BeymenCase.ConfLib;
public interface IConfigurationReader
{
    Task<T> GetValue<T>(string key);
}

