namespace BeymenCase.Service.Settings
{
    public class CacheItemSettings
    {
        public const string Authorize = "Authorize";
        public const string Register = "Register";

        public string Key { get; set; }
        public int Db { get; set; }
        public int DataLifeTime { get; set; }
    }
}