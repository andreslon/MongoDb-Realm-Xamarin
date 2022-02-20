using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class Tender : IBaseLocalModel
    {
        public Tender()
        {
        }

        [PrimaryKey]
        public Guid UID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string photoUrl { get; set; }
        public string managerCode { get; set; }
        public string managerName { get; set; }
        public DateTime LastRouteSync { get; set; }
        public SyncStatus RoutesSyncStatus { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Route> Routes { get; set; }


        #region Internal properties
        [JsonIgnore]
        public Guid ForemanUID { get; set; }
        [JsonIgnore]
        [Indexed]
        public bool IsOtherTender { get; set; }
        #endregion
    }
}
