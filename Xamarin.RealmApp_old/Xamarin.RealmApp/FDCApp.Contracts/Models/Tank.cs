using Newtonsoft.Json;
using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class Tank : IBaseLocalModel, INewAsset
    {
        [Indexed]
        public Guid Id { get; set; }
        public TankProduct Product { get; set; }
        public string TankId { get; set; }
        public string Description { get; set; }
        public string AssocWell { get; set; }
        public string DivisionOfWater { get; set; }
        public double Capacity { get; set; }
        public double HeightFeet { get; set; }
        public string Directions { get; set; }
        public string Comments { get; set; }


        #region Internal properties
        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public Guid UID { get; set; }
        #endregion
    }

    public enum TankProduct
    {
        Oil = 1,
        Water
    }
}
