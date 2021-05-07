using Faro.MetrologyManager.Adapters.EFCore.Contexts.Interfaces;
using Faro.MetrologyManager.EFCore.Contexts;
using Faro.MetrologyManager.Infra.CrossCutting.Builders.ConfigurationBuilder;
using Faro.MetrologyManagerInfra.CrossCutting.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Faro.MetrologyManager.Adapters.SqlServer.Contexts
{
    public class SqlServerContext : DefaultContext, IDbContext
    {
        public SqlServerContext(Config config) 
            : base(config)
        {

        }

        protected override void OnConfiguringInternal(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.SqlServerConfiguration.ConnectionString);
        }
    }

    public class OracleContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            return new SqlServerContext(
                ConfigurationBuilderUtils.GetConfigurationBuilder(null).Build().Get<Config>()
            );
        }
    }
}
