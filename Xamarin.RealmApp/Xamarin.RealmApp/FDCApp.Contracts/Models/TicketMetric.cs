using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class MetricTicket : IBaseLocalModel
    {
        public MetricTicket()
        {

        }

        [PrimaryKey]
        public Guid UID { get; set; }
        public string Name { get; set; }
        public Guid MetricUid { get; set; }        
        public string MetricType { get; set; }
        public string Value { get; set; }
        public string ValueText { get; set; }
        public string Format { get; set; }
        public string Component { get; set; }
        public bool Visible { get; set; }
        public int Order { get; set; }
        public int Section { get; set; }
        public string Validation { get; set; }
        public string Formula { get; set; }

        [TextBlob(nameof(CalculationUidsBlobbed))]
        public List<string> CalculationUids { get; set; }

        [Indexed]
        public string MetricCode { get; set; }

        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Ticket))]
        public Guid TicketId { get; set; }

        [JsonIgnore]
        [ForeignKey(typeof(TicketTemplate))]
        public Guid TicketTemplateId { get; set; }

        [JsonIgnore]
        public string CalculationUidsBlobbed { get; set; }
        #endregion
    }
}
