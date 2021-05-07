using Faro.MetrologyManager.Domain.Entities.Points;
using Faro.MetrologyManager.Domain.Factories;
using Faro.MetrologyManager.Domain.Factories.Interfaces;
using Faro.MetrologyManager.Domain.Services;
using Faro.MetrologyManager.Domain.Services.Interfaces;
using Faro.MetrologyManager.Domain.Specifications.Points;
using Faro.MetrologyManager.Domain.Specifications.Points.Interfaces;
using Faro.MetrologyManager.Domain.Validators.Points;
using Faro.MetrologyManager.Domain.Validators.Points.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Domain.IoC
{
    public static class DomainInjectionManager
    {
        public static void Inject(IServiceCollection services, List<(Type from, Type to)> mapperCollection)
        {
            services.AddScoped<IPointSpecification<Point>, PointSpecification<Point>>();
            services.AddScoped<IActualPointSpecification<ActualPoint>, ActualPointSpecification<ActualPoint>>();

            services.AddScoped<IIsPointValidToAddOrUpdateValidator, IsPointValidToAddOrUpdateValidator>();
            services.AddScoped<IIsActualPointValidToAddOrUpdateValidator, IsActualPointValidToAddOrUpdateValidator>();

            services.AddScoped<IPointService, PointService>();

            services.AddScoped<IPointFactory, PointFactory>();
            services.AddScoped<IActualPointFactory, ActualPointFactory>();
        }
    }
}
