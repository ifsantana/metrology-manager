using Faro.MetrologyManagerInfra.CrossCutting.Configs;
using System.Text.Json;

namespace Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static T DeserializeFromJson<T>(this string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, Config.JsonSerializerOptions);
        }
    }
}
