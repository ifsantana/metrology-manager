using Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories;
using Faro.MetrologyManager.Adapters.EFCore.DataModelRepositories.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModels;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Adapters.EFCore.IoC
{
    public static class EFCoreInjectionManager
    {
        public static void Inject(IServiceCollection services, List<(Type from, Type to)> mapperCollection)
        {
            services.AddScoped<INominalPointDataModelRepository, NominalPointDataModelRepository>();
            services.AddScoped<IActualPointDataModelRepository, ActualPointDataModelRepository>();
            
            mapperCollection.Add((typeof(AddedPoint), typeof(NominalPointDataModel)));
            mapperCollection.Add((typeof(AddedActualPoint), typeof(ActualPointDataModel)));
        }
    }
}
