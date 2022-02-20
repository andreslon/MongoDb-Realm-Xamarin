using System;
using System.Collections.Generic;
using System.Linq;
using FDCApp.Contracts.Constants;
using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class Ticket
    {
        public SyncAction SyncAction { get; set; }
        public TicketStatus StorageStatus { get; set; } 

        public string TicketTitle
        {
            get
            {
                return $"{TypeShort} - {Number}";
            }
        }

        [JsonIgnore]
        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }

        [JsonIgnore]
        public SyncStatusLocal SyncStatus { get; set; }

        [Ignore]
        [JsonIgnore]
        public DateTime HaulDate
        {
            get
            {
                DateTime result = TicketDate;
                if (TicketValueMetrics.Any())
                {
                    var haulDateMetric = TicketValueMetrics.FirstOrDefault(a => a.MetricCode == MetricIdentifier.Ticket_Haul_Date);
                    if (haulDateMetric != null)
                    {
                        result = DateTime.Parse(haulDateMetric.Value);
                    }
                }

                return result;
            }
        }

        [Ignore]
        [JsonIgnore]
        public List<TicketValueMetric> OrderedValueMetrics
        {
            get
            {
                return GetOrderedValueMetrics();
            }
        }

        [Ignore]
        [JsonIgnore]
        public bool IsEditableTicket
        {
            get
            {
                var haulDate = TicketValueMetrics.FirstOrDefault(a => a.MetricCode == MetricIdentifier.Ticket_Haul_Date);
                if (haulDate != null)
                {
                    DateTime minDate = DateTime.Today.AddDays(-30);
                    DateTime ticketDate;
                    if (DateTime.TryParse(haulDate.Value, out ticketDate)) 
                    {
                        if (ticketDate < minDate)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        private List<TicketValueMetric> GetOrderedValueMetrics()
        {
            return this.TicketValueMetrics.OrderBy(a => a.Name).ToList();
        }
    }
}
