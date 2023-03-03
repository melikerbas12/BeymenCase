using BeymenCase.Service.Services;

namespace BeymenCase.Configuration
{
    public class ConfigurationReader
    {

    //     private string applicationName;
    //     private int refreshTimerIntervalInMS;

    //     private readonly ISettingService settingService;

    //     //Cache
    //     private ICacheService cacheService;
    //     private readonly string cacheServiceHost = "localhost";
    //     private readonly string cacheServicePort = "6379";

    //     public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMS)
    //     {
    //         //Storage (MongoDB) repository oluşturuluyor.
    //         configurationsRepo = new MongoDBRepository<Configuration>(new MongoConnectionSettings() { CollectionName = "Configuration",DatabaseName = "BeymenDB",ConnectionString = connectionString});
            
    //         this.applicationName = applicationName;
    //         this.refreshTimerIntervalInMS = refreshTimerIntervalInMS;
    //         //Cache service oluşturuluyor.
    //         cacheService = new RedisCacheService(new RedisServer(cacheServiceHost,cacheServicePort));
    //     }

    //     public async Task<T> GetValue<T>(string key)
    //     {
    //         //Istenen key'e ait kayıt önce cache de var mı kontrol ediliyor.
    //         var configFromCache = GetConfigurationFromCache(key);
    //         if(configFromCache != null)
    //         {
    //             //Cache de mevcut.Expire time kontrol edilecek.Expire time süresi dolmuşsa storage (MongoDB) den yeni veri getirilecek.
    //             if(configFromCache.ExpireTime > DateTime.UtcNow) {
    //                 //Expire süresi geçmemişse değer cache den döndürülüyor.
    //                 return (T)Convert.ChangeType(configFromCache.ConfigurationObj.Value, typeof(T));
    //             }
    //             else
    //             {
    //                 //Expire süresi geçmişse yenileme zamanı gelmiş demektir.Değer storage (MongoDB) den getirilecek.
    //                 var config = await GetActiveConfigurationsOfKey(key);
    //                 if(config!= null)
    //                 {
    //                     //Cachedeki değer güncelleniyor.
    //                     UpdateCache(key, config);
    //                     //Değer storage (MongoDB) den döndürülüyor.
    //                     return (T)Convert.ChangeType(config.Value, typeof(T));
    //                 }
    //                 else
    //                 {
    //                     //Cache de ve storage de değer bulunamadığı için null dönülüyor.
    //                     return (T)(object)null;
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             //Cache mevcut değil.Storage (mongoDB) den getirilecek değer döndürülecek ve cache ye kaydedilecek.
    //             var config = await GetActiveConfigurationsOfKey(key);
    //             if(config != null)
    //             {
    //                 //cachdedeki değer güncelleniyor.
    //                 UpdateCache(key, config);
    //                 //Değer storage (MongoDB) den döndürülüyor.
    //                 return (T)Convert.ChangeType(config.Value, typeof(T));
    //             }
    //             else
    //             {
    //                 //Cache de ve storage de değer bulunamadığı için null dönülüyor.
    //                 //  return (T)(object)null;
    //                 throw new Exception("Config Not Found");
    //             }

    //         }

    //     }
    //     //Storage (MongoDB) den uygulamaya ait aktif kayıtları getiren method
    //     private async Task<Configuration> GetActiveConfigurationsOfKey(string key)
    //     {
    //         try
    //         {
    //             var filter = Builders<Configuration>.Filter.Where(o => o.ApplicationName.Equals(this.applicationName) && o.IsActive == true && o.Name.Equals(key));
    //             return await configurationsRepo.Get(filter);
    //         }catch(Exception exc)
    //         {
    //             return null;
    //         }
 
    //     }

    //     //Cache den kayıtları getiren method
    //     private ConfigurationCacheModel GetConfigurationFromCache(string key) {
    //         string cacheID = applicationName + "_" + key;
    //         if (cacheService.Any(cacheID))
    //         {
    //             return cacheService.Get<ConfigurationCacheModel>(cacheID);
    //         }
    //         else
    //         {
    //             return null;
    //         }
      
    //     }

    //     //Cache deki kaydı güncelleyen method
    //     private void UpdateCache(string key, Configuration configuration)
    //     {
    //         string cacheID = applicationName + "_" + key;
    //         cacheService.Remove(cacheID);
    //         cacheService.Add(cacheID, new ConfigurationCacheModel(cacheID, configuration, DateTime.UtcNow.AddMilliseconds(refreshTimerIntervalInMS)));
    //     }

    // }
}
}