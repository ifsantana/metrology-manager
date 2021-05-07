﻿using Faro.MetrologyManager.Infra.CrossCutting.ExtensionMethods.Models;
using System;
using System.Collections.Generic;

namespace Faro.MetrologyManager.Ports.Api.Controllers.v1.Point.Responses.GetNominalPointsCollection.Models
{
    public class NominalPointResponseModel
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
        public SerializedVector3 AveragePointFromActualPoints { get; set; }
        public List<NominalActualPointsModelResponse> ActualPointsCollection { get; set; }
    }
}
