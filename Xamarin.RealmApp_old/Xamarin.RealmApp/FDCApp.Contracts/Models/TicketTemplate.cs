using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class TicketTemplate : IBaseLocalModel
    {
        [PrimaryKey]
        public Guid UID { get; set; }
        public Guid VisitAssetUid { get; set; }
        public string Number { get; set; }        
        public string Type { get; set; }
        public string TypeShort { get; set; }
        public string TypeGroup { get; set; }
        public string Comment { get; set; }        
        public string Image { get; set; }        
        public int Status { get; set; }        
        public DateTime TicketDate { get; set; }
        public SyncAction SyncAction { get; set; }

        [Indexed]
        public Guid TypeUid { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<MetricTicket> Metrics { get; set; }


        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }

        [JsonIgnore]
        public string UserNumber { get; set; }          
        #endregion
    }
}
