using BeymenCase.Core.Models;
using BeymenCase.Core.Models.Dtos;

namespace BeymenCase.Service.Utilities.Helpers
{
    public static class MappingHelper
    {
        public static K ConvertDtoModel<T, K>(T dto, K model) where T : class, IDto, new()
        where K : class, IEntity, new()
        {
            Type dtoType = typeof(T);
            Type modelType = typeof(K);

            var dtoProperties = dtoType.GetProperties().Select(x => x.Name).Except(new List<string>{"Id"});
            var dbModelProperties = modelType.GetProperties().Select(x => x.Name).Except(new List<string>{"Id"});

            foreach (var dtoPropertyName in dtoProperties)
            {
                foreach (var modelPropertyName in dbModelProperties)
                {
                    if (dtoPropertyName == modelPropertyName)
                    {
                        var value = dtoType.GetProperty(dtoPropertyName).GetValue(dto, null);
                        var property = modelType.GetProperty(dtoPropertyName);

                        if (value == null )
                        {
                            property.SetValue(model, property.GetValue(model, null));
                        }
                        else
                        {
                            property.SetValue(model, value);

                        }
                    }
                }
            }
            return model;
        }
    }
}