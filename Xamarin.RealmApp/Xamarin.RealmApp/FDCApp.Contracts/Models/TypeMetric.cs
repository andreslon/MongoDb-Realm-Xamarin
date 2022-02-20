using System;
using System.Collections.Generic;
using FDCApp.Contracts.Enumerations;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class TypeMetric : IBaseLocalModel
    {
        public TypeMetric()
        {
            UID = Guid.NewGuid();

            CalculationUids = new List<string>();
            RelatedItems = new List<string>();
            ControlSize = DynamicControlSize.Large;
            IsEnabled = true;

            _applyToList = new List<string>();
        }

        [PrimaryKey]
        public Guid UID { get; set; }

        [Indexed]
        public Guid AssetTypeUid { get; set; }        

        [Indexed]
        public Guid MetricId { get; set; }

        [Indexed]
        public string MetricCode { get; set; }

        public string AssetTypeName { get; set; }
        public string Name { get; set; }
        public string MetricType { get; set; }        
        public string Format { get; set; }
        public int MetricStatus { get; set; }
        public string Component { get; set; }
        public bool CarryForward { get; set; }
        public bool MetricStaticprop { get; set; }
        public bool Visible { get; set; }
        public bool MetricSearchflag { get; set; }
        public string Validation { get; set; }
        public string Formula { get; set; }
        public string FormulaFunction { get; set; }
        public int Section { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsEnabled { get; set; }        
        public int Order { get; set; }
        public string DefaultValue { get; set; }
        public string DefaultValueText { get; set; }
        public int MaxLength { get; set; }
        public DynamicControlSize ControlSize { get; set; }
        public int RowSpan { get; set; } = 1;
        public int ColumnSpan { get; set; } = 1;
        public bool IncludeUnitsOnTitle { get; set; }
        public string Units { get; set; }
        public string GroupCode { get; set; }
        public string GroupSubCode { get; set; }
        public string ApplyTo { get; set; }

        [TextBlob(nameof(CalculationUidsBlobbed))]
        public List<string> CalculationUids { get; set; }

        [TextBlob(nameof(RelatedItemsBlobbed))]
        public List<string> RelatedItems { get; set; }
    }
}
