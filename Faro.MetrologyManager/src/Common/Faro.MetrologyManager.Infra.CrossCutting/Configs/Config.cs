
using Faro.MetrologyManager.Infra.CrossCutting.Configs.Elastic;
using Faro.MetrologyManager.Infra.CrossCutting.Configs.SqlServer;
using System.Text.Json;

namespace Faro.MetrologyManagerInfra.CrossCutting.Configs
{
    public class Config
    {
        public const string SYSTEM_USERNAME = "MetrodolyManager";

        public static JsonSerializerOptions JsonSerializerOptions => new JsonSerializerOptions(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        
        public ElasticConfiguration ElasticConfiguration { get; set; }
        public SqlConfiguration SqlServerConfiguration { get; set; }
    }
}
