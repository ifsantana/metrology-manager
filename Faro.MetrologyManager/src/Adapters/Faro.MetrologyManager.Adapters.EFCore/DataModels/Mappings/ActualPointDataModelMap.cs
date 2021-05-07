using Faro.MetrologyManager.Adapters.EFCore.DataModels.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModels.Mappings
{
    public class ActualPointDataModelMap : MapBase<ActualPointDataModel>
    {
        private static string TABLE_NAME = "ACTUAL_POINT";

        protected override string GetTableName() => TABLE_NAME;

        public override void ConfigureMap(EntityTypeBuilder<ActualPointDataModel> builder)
        {
            builder.Property(q => q.NominalPointId)
                .HasColumnName("NOMINAL_POINT_ID")
                .IsRequired();

            builder.HasIndex(q => q.NominalPointId)
                .HasDatabaseName($"IX_{TABLE_NAME}_NOMINAL_POINT");

            builder.Property(q => q.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(q => q.X)
                .HasColumnName("X") //width
                .HasPrecision(38, 16)
                .IsRequired();

            builder.Property(q => q.Y)
                .HasColumnName("Y") //height
                .HasPrecision(38, 16)
                .IsRequired();

            builder.Property(q => q.Z)
                .HasColumnName("Z") // depth
                .HasPrecision(38, 16)
                .IsRequired();
        }
    }
}
