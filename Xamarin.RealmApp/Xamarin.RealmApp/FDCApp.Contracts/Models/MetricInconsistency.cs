using System;
using Newtonsoft.Json;

namespace FDCApp.Contracts.Models
{
    public class MetricInconsistency
    {
        public Guid AssetId { get; set; }
        public Guid VisitAssetId { get; set; }
        public Guid VisitMetricId { get; set; }
        public Guid MetricId { get; set; }
        public int InconsistencyType { get; set; }
        public string DeviceValue { get; set; }
        public string RemoteValue { get; set; }
        public DateTime DeviceTimestamp { get; set; }
        public DateTime RemoteTimestamp { get; set; }

        [JsonIgnore]
        public DateTime MetricDate { get; set; }
    }
}