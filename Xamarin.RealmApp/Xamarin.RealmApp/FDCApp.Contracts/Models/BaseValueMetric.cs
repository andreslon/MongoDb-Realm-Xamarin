using System;
using FDCApp.Contracts.Enumerations;
using SQLite;

namespace FDCApp.Contracts.Models
{
    public class BaseValueMetric 
    {
        public BaseValueMetric()
        {
            CreationStatus = CreationStatus.None;
        }

        public DateTime MetricDate { get; set; }
        public Guid MetricId { get; set; }        

        [Indexed]
        public string MetricCode { get; set; }        
        public string Name { get; set; }
        public string Value { get; set; }
        public string ValueText { get; set; }
        public bool IsToday { get; set; }
        public decimal CalculationFactor { get; set; }

        public DateTime LastUpdate { get; set; }
        public Guid LastUpdateUserId { get; set; }
        public string LastUpdateUserName { get; set; }
        public string SourceSystem { get; set; }
        public EntryTypes EntryType { get; set; }

        public Guid? ProductionMethodBeforeUid { get; set; }
        public string ProductionMethodBeforeText { get; set; }

        public string DeviceId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        #region Internal properties
        public SyncStatusLocal SyncStatus { get; set; }
        public CreationStatus CreationStatus { get; set; }
        #endregion
    }
}
