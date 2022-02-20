using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class MetricBeyond : BaseMetric, IBaseLocalModel
    {
        public MetricBeyond()
        {
            
        }

        [PrimaryKey]
        public Guid UID { get; set; }
        
        public MetricBeyond Clone()
        {
            return (MetricBeyond)MemberwiseClone();
        }
    }
}
