using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public class DomesticLocationData : IBaseLocalModel
    {
        public DomesticLocationData()
        {
            UID = Guid.NewGuid();
        }

        [PrimaryKey]
        public Guid UID { get; set; }

        public string ReadFrequency { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAccountNumber { get; set; }

        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }
    }
}
