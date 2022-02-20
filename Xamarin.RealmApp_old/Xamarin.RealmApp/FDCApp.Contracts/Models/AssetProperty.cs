using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace FDCApp.Contracts.Models
{
    public class AssetProperty : IBaseLocalModel
    {
        [PrimaryKey]
        public Guid UID { get; set; }

        [JsonProperty("metricId")]
        public Guid MetricUID { get; set; }

        [Indexed]
        public string MetricCode { get; set; }
        public string MetricName { get; set; }
        public string Value { get; set; }
        public bool Visible { get; set; }

        [Indexed]
        //[ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }

        [Indexed]
        //[ForeignKey(typeof(Site))]
        public Guid SiteId { get; set; }

        [Indexed]
        [ForeignKey(typeof(Route))]
        public Guid RouteId { get; set; }
    }
}
