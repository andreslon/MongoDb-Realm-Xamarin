using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace FDCApp.Contracts.Models
{
    public class VisitReason : IBaseLocalModel
    {
        [PrimaryKey]
        [JsonProperty("id")]
        public Guid UID { get; set; }

        [Indexed]
        [ForeignKey(typeof(VisitSite))]
        public Guid VisitSiteId { get; set; }
        public Guid ReasonId { get; set; }
        public DateTime VisitReasonDate { get; set; }
        public string ReasonName { get; set; }
    }
}
