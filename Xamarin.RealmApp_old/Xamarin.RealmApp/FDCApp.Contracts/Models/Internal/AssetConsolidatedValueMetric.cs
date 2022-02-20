using System;
using SQLite;

namespace FDCApp.Contracts.Models.Internal
{
    public class AssetConsolidatedValueMetric : BaseValueMetric, IBaseLocalModel
    {
        public AssetConsolidatedValueMetric()
        {
        }

        [PrimaryKey]
        public Guid UID { get; set; }

        [Indexed]
        public Guid AssetId { get; set; }        
    }
}
