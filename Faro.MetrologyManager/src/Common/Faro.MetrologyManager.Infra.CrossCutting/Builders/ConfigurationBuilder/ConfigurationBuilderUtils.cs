using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Faro.MetrologyManager.Infra.CrossCutting.Builders.ConfigurationBuilder
{
    public static class ConfigurationBuilderUtils
    {
        public static IConfigurationBuilder GetConfigurationBuilder(string environmentName = null)
        {
            var configurationBuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))
                .AddUserSecrets("Faro.MetrologyManager.Ports.Api")
                .AddEnvironmentVariables();

            if (!string.IsNullOrWhiteSpace(environmentName))
                configurationBuilder = configurationBuilder.AddJsonFile(Path.Combine(AppContext.BaseDirectory, $"appsettings.{environmentName}.json"), true);

            return configurationBuilder;
        }
    }
}
