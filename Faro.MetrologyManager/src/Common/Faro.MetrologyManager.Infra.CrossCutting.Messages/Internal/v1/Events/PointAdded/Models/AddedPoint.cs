using System;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Infra.CrossCutting.Messages.Internal.v1.Events.PointAdded.Models
{
    public class AddedPoint
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TimeSpan RowVersion { get; set; }
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public List<ActualPointEventModel> ActualPointsCollection { get; set; }
    }
}
