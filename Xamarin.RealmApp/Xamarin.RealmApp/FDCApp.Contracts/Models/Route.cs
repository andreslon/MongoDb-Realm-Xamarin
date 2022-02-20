using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class Route : IBaseLocalModel
    {
        public Route()
        {
            Sites = new List<Site>();
        }

        [PrimaryKey, Indexed]
        public Guid UID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime LastSitesSync { get; set; }
        public SyncStatus SitesSyncStatus { get; set; }
        

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Site> Sites { get; set; }

        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Tender))]
        public Guid TenderUID { get; set; }        
        #endregion
    }
}
