using System;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public class TicketDefaultValueMetric : BaseValueMetric, IBaseLocalModel
    {
        public TicketDefaultValueMetric()
        {
        }

        [PrimaryKey]
        public Guid UID { get; set; }

        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(TicketTemplateHeader))]
        public Guid TicketTemplateHeaderId { get; set; }
        #endregion
    }
}
