using Faro.MetrologyManager.Domain.Factories.Interfaces;
using Faro.MetrologyManager.Tests;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Faro.MetrologyManager.Domain.Tests.Factories
{
    public class PointFactoryTest : TestBase
	{
		protected override void ConfigureServices(IServiceCollection services)
		{

		}

		[Fact]
		[Trait("Factories", nameof(PointFactoryTest))]
		public void PointFactory_Should_Create()
		{
			// Arrange
			var factory = ServiceProvider.GetService<IPointFactory>();

			// Act
			var entity = factory.Create();

			// Assert
			entity.Should().Be(default);
		}

		[Fact]
		[Trait("Factories", nameof(PointFactoryTest))]
		public void PointFactoryWithParameter_Should_Create()
		{
			// Arrange
			var factory = ServiceProvider.GetService<IPointFactory>();

			// Act
			var entity = factory.Create("Nominal Point");

			// Assert
			entity.Name.Should().Be("Nominal Point");
		}
	}
}
