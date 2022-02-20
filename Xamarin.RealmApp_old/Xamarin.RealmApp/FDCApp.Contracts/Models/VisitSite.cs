using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class VisitSite : IBaseLocalModel
    {
        public VisitSite()
        {
            SyncStatus = SyncStatusLocal.None;
        }

        [PrimaryKey]
        [JsonProperty("visitSiteId")]
        public Guid UID { get; set; }

        [ForeignKey(typeof(Site))]
        public Guid SiteId { get; set; }

        public Guid OperatorId { get; set; }
        public DateTime VisitDate { get; set; }
        public bool IsInternal { get; set; }

        [JsonIgnore]
        public SyncStatusLocal SyncStatus { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<VisitReason> Reasons { get; set; }        
    }
}
