using Newtonsoft.Json;
using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public enum MeterType
    {
        Electronic = 1,
        Orifice,
        Rotary
    }

    public enum MeterDisposition
    {
        CheckMeter = 1,
        MasterMeter,
        WellheadMeter,
        Fuel,
        ThirdParty
    }

    public class Meter : IBaseLocalModel, INewAsset
    {
        [Indexed]
        public Guid Id { get; set; }
        public string MeterId { get; set; }
        public string Name { get; set; }
        public MeterType Type { get; set; }
        public MeterDisposition Disposition { get; set; }
        public decimal Orifice { get; set; }
        public decimal TubeSize { get; set; }
        public int? NumberOfDialsIfRotary { get; set; }
        public string Directions { get; set; }
        public string Comments { get; set; }


        #region Internal properties
        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public Guid UID { get; set; }
        #endregion
    }
}
