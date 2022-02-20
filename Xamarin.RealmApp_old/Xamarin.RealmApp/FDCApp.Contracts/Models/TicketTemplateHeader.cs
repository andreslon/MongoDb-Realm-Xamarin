using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public class TicketTemplateHeader : IBaseLocalModel
    {
        public TicketTemplateHeader()
        {
            UID = Guid.NewGuid();
        }

        [PrimaryKey]
        public Guid UID { get; set; }
        public string Number { get; set; }
        public Guid TypeUid { get; set; }

        [JsonProperty("metrics")]
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TicketDefaultValueMetric> DefaultValueMetrics { get; set; }

        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }
        #endregion
    }
}
