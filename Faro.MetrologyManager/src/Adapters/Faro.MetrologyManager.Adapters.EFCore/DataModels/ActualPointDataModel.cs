using Faro.MetrologyManager.Adapters.EFCore.DataModels.Base;
using System;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ActualPointDataModel : DataModelBase
    {
        public Guid NominalPointId { get; set; }
        public string Name { get; protected set; }
        public decimal X { get; protected set; }
        public decimal Y { get; protected set; }
        public decimal Z { get; protected set; }

        public NominalPointDataModel NominalPoint { get; set; }

        public ActualPointDataModel()
        {
            Name = string.Empty;
            X = decimal.MinValue;
            Y = decimal.MinValue;
            X = decimal.MinValue;
        }
    }
}
