using Faro.MetrologyManager.Adapters.EFCore.Contexts.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModels;
using Faro.MetrologyManager.Adapters.SqlServer.Contexts;
using Faro.MetrologyManager.Adapters.SqlServer.Repositories;
using Faro.MetrologyManager.Adapters.SqlServer.Repositories.Interfaces;
using Faro.MetrologyManager.Adapters.SqlServer.UnitOfWork;
using Faro.MetrologyManager.Adapters.SqlServer.UnitOfWork.Interfaces;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollectionById.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Adapters.SqlServer.IoC
{
    public static class SqlServerInjectionManager
    {
        public static void Inject(IServiceCollection services, List<(Type from, Type to)> mapperCollection)
        {
            services.AddScoped<ISqlServerUnitOfWork, SqlServerUnitOfWork>();
            services.AddScoped<IPointSqlServerRepository, PointSqlServerRepository>();
            
            services.AddDbContext<IDbContext, SqlServerContext>();

            mapperCollection.Add((typeof(Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models.AddedPoint), typeof(NominalPointDataModel)));
            mapperCollection.Add((typeof(NominalPointDataModel), typeof(NominalPointsCollectionByIdQueryReturnModel))); 
            mapperCollection.Add((typeof(ActualPointDataModel), typeof(ActualPointQueryReturnModel)));
        }
    }
}
