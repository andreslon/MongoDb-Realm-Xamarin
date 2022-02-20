using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class BaseMetric
    {
        public BaseMetric()
        {
            list = new List<MetricList>();
            RelatedItems = new List<string>();
            CalculationUids = new List<string>();
            ControlSize = DynamicControlSize.Large;
            IsEnabled = true;
        }

        public Guid VisitAssetId { get; set; }
        public DateTime MetricDate { get; set; }
        public Guid MetricId { get; set; }        
        public string Name { get; set; }
        public string MetricType { get; set; }
        public string Value { get; set; }
        public string ValueText { get; set; }
        public string DefaultValue { get; set; }
        public string DefaultValueText { get; set; }
        public string ProductionMethodBeforeUid { get; set; }
        public string ProductionMethodBeforeText { get; set; }
        public string Format { get; set; }
        public string Component { get; set; }
        public bool CarryForward { get; set; }
        public bool Visible { get; set; }
        public string Validation { get; set; }
        public string Formula { get; set; }
        public int Status { get; set; }
        public int Order { get; set; }
        public int Section { get; set; }
        public decimal CalculationFactor { get; set; }
        public string FormulaFunction { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime LastUpdate { get; set; }
        public int MaxLength { get; set; }
        public SyncStatusLocal SyncStatus { get; set; }
        public string RelatedItemsBlobbed { get; set; }

        [TextBlob(nameof(CalculationUidsBlobbed))]
        public List<string> CalculationUids { get; set; }

        [TextBlob(nameof(RelatedItemsBlobbed))]
        public List<string> RelatedItems { get; set; }

        [Ignore]
        public List<MetricList> list { get; set; }

        [Indexed]
        public string MetricCode { get; set; }

        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }

        [JsonIgnore]
        public bool IsCarryForwardedValue { get; set; }

        [JsonIgnore]
        public bool IsDefaultValue { get; set; }

        [JsonIgnore]
        public string CalculationUidsBlobbed { get; set; }

        [JsonIgnore]
        public DynamicControlSize ControlSize { get; set; }        
        #endregion        
    }
}
