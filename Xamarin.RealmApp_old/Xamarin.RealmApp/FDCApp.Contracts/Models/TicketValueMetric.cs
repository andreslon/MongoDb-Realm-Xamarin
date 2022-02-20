using System;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public class TicketValueMetric : BaseValueMetric, IBaseLocalModel
    {
        public TicketValueMetric()
        {
        }

        [PrimaryKey]
        public Guid UID { get; set; }         

        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Ticket))]
        public Guid TicketId { get; set; }

        public string DisplayValue
        {
            get
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(ValueText))
                    {
                        return ValueText;
                    }
                    else
                    {
                        return Value;
                    }
                }
                catch
                {
                    return "";
                }
            }
        }

        public string DisplayValueFormatted { get; set; }
        #endregion
    }
}
