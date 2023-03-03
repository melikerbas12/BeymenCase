namespace BeymenCase.Configuration
{
    public interface IConfigurationReader
    {
        T GetValue<T>(string key);
    }
}