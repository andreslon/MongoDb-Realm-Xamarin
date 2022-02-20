using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace FDCApp.Contracts.Models
{
    public class Note 
    {        
        [PrimaryKey]
        public Guid Id { get; set; }
        public Guid VisitAssetId { get; set; }
        public Guid OperatorId { get; set; }
        public string OperatorName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }        
        public SyncAction  SyncAction { get; set; }


        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }
        #endregion
    }
}
