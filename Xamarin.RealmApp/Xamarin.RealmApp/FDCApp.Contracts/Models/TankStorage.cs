using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace FDCApp.Contracts.Models
{
    public class TankStorage
    {
        public decimal? TotalTankStorage { get; set; }
        public decimal? LargestLinkedTank { get; set; }


        #region Internal properties
        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public int LocalId { get; set; }

        [JsonIgnore]
        [ForeignKey(typeof(Site))]
        public Guid LocalSiteId { get; set; }
        #endregion
    }
}
