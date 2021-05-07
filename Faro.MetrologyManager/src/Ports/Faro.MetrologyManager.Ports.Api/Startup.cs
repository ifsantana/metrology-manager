using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetActualPointsCollectionByNominalPointId.Models;
using Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Queries.GetNominalPointsCollection.Models;
using Faro.MetrologyManager.Infra.IoC;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetActualPointsByNominalPointIdCollection;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetActualPointsByNominalPointIdCollection.Models;
using Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetNominalPointsCollection.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO.Compression;

namespace Faro.MetrologyManager.Ports.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private readonly string AllowSpecificOrigins = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });

            services.Inject(_configuration, new System.Collections.Generic.List<(Type from, Type to)> {

                 (typeof(GetNominalPointsCollectionQueryReturn), typeof(GetNominalPointsCollectionResponse)),
                 (typeof(GetNominalPointsCollectionQueryReturnModel), typeof(NominalPointResponseModel)),
                 (typeof(GetActualPointsCollectionByNominalPointIdQueryReturn), typeof(GetActualPointsByNominalPointIdCollectionResponse)),
                 (typeof(ActualPointsCollectionByNominalPointIdReturnModel), typeof(ActualPointModelResponse)),
                 (typeof(GetNominalPointsByIdActualPointsQueryReturnModel), typeof(NominalActualPointsModelResponse))
                 

            });

            services.AddControllers();

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Faro.MetrologyManager.Ports.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Faro.MetrologyManager.Ports.Api v1"));
            }

            app.UseCors("CorsPolicy");
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
