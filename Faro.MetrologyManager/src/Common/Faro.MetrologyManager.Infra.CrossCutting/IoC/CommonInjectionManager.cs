using Faro.MetrologyManager.Infra.CrossCutting.Adapters;
using Faro.MetrologyManager.Infra.CrossCutting.Adapters.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Builders.ConfigurationBuilder;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods;
using Faro.MetrologyManagerInfra.CrossCutting.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Network;
using System;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Infra.CrossCutting.IoC
{
    public static class CommonInjectionManager
    {
        private static string APPLICATION_NAME = "Faro.MetrologyManager";

        public static void Inject(IServiceCollection services, IConfiguration existingConfiguration, List<(Type from, Type to)> mapperCollection)
        {

            var configuration = existingConfiguration;

            if (configuration is null)
            {
                configuration = ConfigurationBuilderUtils.GetConfigurationBuilder().Build();
                services.AddSingleton(configuration);
            }

            var config = configuration.Get<Config>();
            services.AddSingleton(config);

            Log.Logger = new LoggerConfiguration()
                              .Enrich.WithMachineName()
                              .Enrich.WithProcessId()
                              .Enrich.WithThreadId()
                              .Enrich.WithProperty(APPLICATION_NAME, config.ElasticConfiguration.ApplicationName)
                              .Enrich.WithExceptionDetails()
                              .MinimumLevel.Is(LogEventLevel.Debug)
                              .WriteTo.Console()
                              .WriteTo.UDPSink(config.ElasticConfiguration.Uri, config.ElasticConfiguration.Port)
                              .CreateLogger();

            services.AddSingleton(Log.Logger);

            Log.Logger.Warning($"Loaded Config - {config.SerializeToJson()}");

            services.AddScoped<IRaisedDomainNotifications, RaisedDomainNotifications>();
            services.AddScoped<IAdapter, Adapter>();
            services.AddScoped<IBus, Bus.Bus>();
        }
    }
}
