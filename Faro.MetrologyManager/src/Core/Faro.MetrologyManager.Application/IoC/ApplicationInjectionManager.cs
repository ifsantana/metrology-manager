using Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint;
using Faro.MetrologyManager.Application.Handlers.Commands.ActualPoint.Interfaces;
using Faro.MetrologyManager.Application.Handlers.Commands.NominalPoint;
using Faro.MetrologyManager.Application.Handlers.Commands.NominalPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddActualPoint;
using Faro.MetrologyManager.Application.UseCases.AddActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddActualPoint.Models;
using Faro.MetrologyManager.Application.UseCases.AddNominalPoint;
using Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.AddNominalPoint.Models;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Interfaces;
using Faro.MetrologyManager.Application.UseCases.RemoveActualPoint.Models;
using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.AddNominalPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Commands.RemoveActualPoint.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.ActualPointRemoved.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddActualPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.FailedToAddPoint;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsByIdCollection.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollectionById.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Application.IoC
{
    public class ApplicationInjectionManager
    {
        public static void Inject(IServiceCollection services, List<(Type from, Type to)> mapperCollection)
        {
            ConfigureHandlers(services);
            ConfigureUseCases(services);

            mapperCollection.Add((typeof(AddNominalPointCommandInput), typeof(AddNominalPointUseCaseInput)));
            mapperCollection.Add((typeof(AddActualPointCommandInput), typeof(AddActualPointUseCaseInput)));
            mapperCollection.Add((typeof(Point), typeof(AddedPoint)));
            mapperCollection.Add((typeof(ActualPoint), typeof(AddedActualPoint)));
            mapperCollection.Add((typeof(AddNominalPointUseCaseInput), typeof(FailedToAddPointEvent)));
            mapperCollection.Add((typeof(AddActualPointUseCaseInput), typeof(FailedToAddActualPointEvent)));
            mapperCollection.Add((typeof(NominalPointsCollectionByIdQueryReturnModel), typeof(Point))); 
            mapperCollection.Add((typeof(ActualPointQueryReturnModel), typeof(ActualPoint)));
            mapperCollection.Add((typeof(RemoveActualPointUseCaseInput), typeof(RemovedActualPoint)));
            mapperCollection.Add((typeof(RemoveActualPointCommandInput), typeof(RemoveActualPointUseCaseInput)));
        }

        private static void ConfigureHandlers(IServiceCollection services)
        {
            services.AddScoped<IAddNominalPointCommandHandler, AddNominalPointCommandHandler>();
            services.AddScoped<IAddActualPointCommandHandler, AddActualPointCommandHandler>();
            services.AddScoped<IRemoveActualPointCommandHandler, RemoveActualPointCommandHandler>();
        }

        private static void ConfigureUseCases(IServiceCollection services)
        {
            services.AddScoped<IAddNominalPointUseCase, AddNominalPointUseCase>();
            services.AddScoped<IAddActualPointUseCase, AddActualPointUseCase>();
            services.AddScoped<IRemoveActualPointUseCase, RemoveActualPointUseCase>();
        }
    }
}
