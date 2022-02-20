using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class MetricAsset : BaseMetric, IBaseLocalModel
    {
        public MetricAsset()
        {
            
        }

        [PrimaryKey]
        public Guid UID { get; set; }

        public int ColumnSpan { get; set; } = 1;
        public int RowSpan { get; set; } = 1;
        public string InternalCode { get; set; }

        public MetricAsset Clone()
        {
            return (MetricAsset)MemberwiseClone();
        }
    }
}
