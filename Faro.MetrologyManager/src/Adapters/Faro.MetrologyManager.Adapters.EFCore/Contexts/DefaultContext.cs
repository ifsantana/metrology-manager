using Faro.MetrologyManager.Adapters.EFCore.Contexts.Interfaces;
using Faro.MetrologyManager.Adapters.EFCore.DataModels.Mappings;
using Faro.MetrologyManagerInfra.CrossCutting.Configs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Faro.MetrologyManager.EFCore.Contexts
{
    public abstract class DefaultContext : DbContext, IDbContext
    {
        protected Config Config { get; }

        protected DefaultContext(Config config)
        {
            Config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            * ApplyMappings() methods must be called before
            * DeleteBehavior manipulation
            */
            ApplyMappings(modelBuilder);
            
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            OnConfiguringInternal(optionsBuilder);
        }
        protected abstract void OnConfiguringInternal(DbContextOptionsBuilder optionsBuilder);

        private static void ApplyMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NominalPointDataModelMap());
            modelBuilder.ApplyConfiguration(new ActualPointDataModelMap());
        }
    }
}
