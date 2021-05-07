using Faro.MetrologyManager.Adapters.EFCore.DataModels.Base;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Adapters.EFCore.DataModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class NominalPointDataModel : DataModelBase
    {
        public string Name { get; protected set; }
        public decimal X { get; protected set; }
        public decimal Y { get; protected set; }
        public decimal Z { get; protected set; }
        public List<ActualPointDataModel> ActualPointsCollection { get; protected set; }

        public NominalPointDataModel()
        {
            Name = string.Empty;
            X = decimal.MinValue;
            Y = decimal.MinValue;
            X = decimal.MinValue;
        }
    }
}
