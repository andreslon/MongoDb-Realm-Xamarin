using System;
using System.Collections.Generic;
using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            TicketValueMetrics = new List<TicketValueMetric>();
            SyncStatus = SyncStatusLocal.None;
        }

        [PrimaryKey]
        public Guid UID { get; set; }
        public Guid VisitAssetUid { get; set; }
        public string Number { get; set; }        
        public Guid TypeUid { get; set; }
        public string Type { get; set; }
        public string TypeShort { get; set; }
        public string TypeGroup { get; set; }
        public string Comment { get; set; }        
        public string Image { get; set; }        
        public int Status { get; set; }         
        public DateTime TicketDate { get; set; }

        [JsonProperty("metrics")]
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TicketValueMetric> TicketValueMetrics { get; set; }
    }
}
