using AutoMapper;
using Faro.MetrologyManager.Adapters.EFCore.IoC;
using Faro.MetrologyManager.Adapters.SqlServer.IoC;
using Faro.MetrologyManager.Adapters.SqlServer.Repositories.Interfaces;
using Faro.MetrologyManager.Adapters.SqlServer.UnitOfWork.Interfaces;
using Faro.MetrologyManager.Application.Handlers.Commands.NominalPoint.Interfaces;
using Faro.MetrologyManager.Application.IoC;
using Faro.MetrologyManager.Domain.IoC;
using Faro.MetrologyManager.Infra.CrossCutting.Bus.Handlers.EventHandlers.DomainNotifications.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.IoC;
using Faro.MetrologyManager.Infra.CrossCutting.UnitOfWork.Interfaces;
using Faro.MetrologyManagerInfra.CrossCutting.Configs;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Faro.MetrologyManager.Infra.IoC
{
    public static class InjectionManager
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration, List<(Type from, Type to)> existingMapperCollection = null)
        {
            var mapperCollectionInternal = new List<(Type from, Type to)>(existingMapperCollection ?? new List<(Type from, Type to)>());

            var config = configuration.Get<Config>();

            services.AddSingleton(configuration);

            ConfigureCommomLayer(services, configuration, mapperCollectionInternal);
            ConfigureApplicationCoreLayer(services, mapperCollectionInternal);
            ConfigureAdaptersLayer(services, config, mapperCollectionInternal);
            ConfigureBusAndMessageHandlerLayer(services, config, mapperCollectionInternal);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                foreach (var (from, to) in mapperCollectionInternal)
                    cfg.CreateMap(from, to);
            }
            );

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }

        private static void ConfigureCommomLayer(IServiceCollection services, IConfiguration configuration, List<(Type from, Type to)> mapperCollection)
        {
            CommonInjectionManager.Inject(services, configuration, mapperCollection);
        }

        private static void ConfigureApplicationCoreLayer(IServiceCollection services, List<(Type from, Type to)> mapperCollection)
        {
            ApplicationInjectionManager.Inject(services, mapperCollection);
            DomainInjectionManager.Inject(services, mapperCollection);
        }
        private static void ConfigureAdaptersLayer(IServiceCollection services, Config config, List<(Type from, Type to)> mapperCollection)
        {
            EFCoreInjectionManager.Inject(services, mapperCollection);
            SqlServerInjectionManager.Inject(services, mapperCollection);

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetService<ISqlServerUnitOfWork>());
        }
        private static void ConfigureBusAndMessageHandlerLayer(IServiceCollection services, Config config, List<(Type from, Type to)> mapperCollection)
        {
            //services.AddScoped<IBus>(serviceProvider =>
            //{
            //    var mediator = serviceProvider.GetService<IMediator>();

            //    return new Bus(mediator, new IEventSendedInterceptor[] {
            //        serviceProvider.GetService<IKafkaAllEventHandler>()
            //    });
            //});

            var assemblyCollection = new List<Assembly> {
                // Commom
                typeof(IDomainNotificationEventHandler).Assembly,
                //// ApplicationCore.Application Layer
                typeof(IAddNominalPointCommandHandler).Assembly,
                //// Kafka Layer
                //typeof(IPosicaoAcaoAberturaDataModelRepository).Assembly,
            };

            assemblyCollection.Add(
                 typeof(IPointSqlServerRepository).Assembly
            );

            services.AddMediatR(config =>
            {
                config.AsTransient();
            },
                assemblyCollection.ToArray()
            );
        }
    }
}
