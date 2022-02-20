using System;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public class AssetValueMetric : BaseValueMetric, IBaseLocalModel
    {
        public AssetValueMetric()
        {
        }

        [PrimaryKey]
        public Guid UID { get; set; }

        [JsonIgnore]
        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }

        public Guid VisitAssetId { get; set; }
    }
}
