using Newtonsoft.Json;
using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class DomesticLocation : IBaseLocalModel, INewAsset
    {
        [Indexed]
        public Guid Id { get; set; }
        public string MeterId { get; set; }
        public string LocationOrCustomerName { get; set; }
        public int? NumberOfDials { get; set; }
        public string Directions { get; set; }
        public string Comments { get; set; }


        #region Internal properties
        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public Guid UID { get; set; }
        #endregion
    }
}
