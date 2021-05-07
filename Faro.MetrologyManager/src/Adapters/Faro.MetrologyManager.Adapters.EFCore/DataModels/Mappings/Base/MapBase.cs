using Faro.MetrologyManager.Adapters.EFCore.DataModels.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModels.Mappings.Base
{
    public abstract class MapBase<TDataModel>
        : IEntityTypeConfiguration<TDataModel>
        where TDataModel : DataModelBase
    {
        private static string SCHEMA_NAME = "MetrologyManager";

        public void Configure(EntityTypeBuilder<TDataModel> builder)
        {
            builder.ToTable(GetTableName(), SCHEMA_NAME);

            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id)
                .HasColumnName("ID");

            builder.Property(q => q.CreatedAt)
                .HasColumnName("CREATED_AT")
                .IsRequired();
            builder.Property(q => q.CreatedBy)
                .HasColumnName("CREATED_BY")
                .HasColumnType("VARCHAR(150)")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(q => q.UpdatedAt)
                .HasColumnName("UPDATED_AT")
                .IsRequired(false);
            builder.Property(q => q.UpdatedBy)
                .HasColumnName("UPDATED_BY")
                .HasColumnType("VARCHAR")
                .IsRequired(false)
                .HasMaxLength(150);

            builder.Property(q => q.RowVersion)
                .HasColumnName("ROW_VERSION")
                .HasColumnType("BIGINT")
                .HasConversion<long>()
                .IsRequired();

            ConfigureMap(builder);
        }

        protected abstract string GetTableName();

        public abstract void ConfigureMap(EntityTypeBuilder<TDataModel> builder);
    }
}
