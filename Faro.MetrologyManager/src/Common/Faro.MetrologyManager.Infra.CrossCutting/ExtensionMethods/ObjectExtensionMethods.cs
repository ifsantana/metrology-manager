using Faro.MetrologyManagerInfra.CrossCutting.Configs;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods
{
	public static class ObjectExtensionMethods
    {
        public static string SerializeToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, Config.JsonSerializerOptions);
        }
        public static byte[] SerializeToByteArray(this object obj)
		{
            byte[] byteArray;
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
				formatter.Serialize(stream, obj);
                byteArray = stream.ToArray();
            }

            return byteArray;
        }
    }
}
