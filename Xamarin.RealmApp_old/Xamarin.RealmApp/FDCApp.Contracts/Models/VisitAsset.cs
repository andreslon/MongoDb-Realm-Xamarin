using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace FDCApp.Contracts.Models
{
    public class VisitAsset
    {
        public VisitAsset()
        {
            IsInternal = false;
            SyncStatus = SyncStatusLocal.None;            
        }

        [PrimaryKey]
        public Guid VisitAssetId { get; set; }
        public Guid VisitSiteId { get; set; }

        [Indexed]
        public DateTime VisitDate { get; set; }
        public bool IsInternal { get; set; }
        public string TankHeight { get; set; }

        [JsonIgnore]
        public SyncStatusLocal SyncStatus { get; set; }

        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }        
    }
}
