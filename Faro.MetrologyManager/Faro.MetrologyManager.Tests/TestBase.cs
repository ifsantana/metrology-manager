using Faro.MetrologyManager.Infra.CrossCutting.Builders.ConfigurationBuilder;
using Faro.MetrologyManager.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Faro.MetrologyManager.Tests
{
    public abstract class TestBase
    {
        // Properties
        protected ServiceProvider ServiceProvider { get; }

        // Constructor
        protected TestBase()
        {
            var services = new ServiceCollection();

            ConfgureServicesInternal(services);

            ServiceProvider = services.BuildServiceProvider();
        }

        // Private Method
        private void ConfgureServicesInternal(IServiceCollection services)
        {
            InjectionManager.Inject(
                services,
                ConfigurationBuilderUtils.GetConfigurationBuilder().Build()
            );

            ConfigureServices(services);
        }

        // Abstract Methods
        protected abstract void ConfigureServices(IServiceCollection services);
    }
}
