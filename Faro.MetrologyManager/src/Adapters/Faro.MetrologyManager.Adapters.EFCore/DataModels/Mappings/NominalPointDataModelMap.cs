using Faro.MetrologyManager.Adapters.EFCore.DataModels.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModels.Mappings
{
    public class NominalPointDataModelMap : MapBase<NominalPointDataModel>
    {
        private static string TABLE_NAME = "NOMINAL_POINT";
        protected override string GetTableName() => TABLE_NAME;

        public override void ConfigureMap(EntityTypeBuilder<NominalPointDataModel> builder)
        {
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
