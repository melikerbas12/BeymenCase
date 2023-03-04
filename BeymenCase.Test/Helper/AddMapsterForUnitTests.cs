using BeymenCase.Core.Contracts;
using Mapster;
using MapsterMapper;

namespace BeymenCase.Test.Helper
{
 public static class AddMapsterForUnitTests
{
    public static Mapper GetMapper()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(SettingContract).Assembly);
        return new Mapper(config);
    }
}
}