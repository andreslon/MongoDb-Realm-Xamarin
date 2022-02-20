using System;
using System.Collections.Generic;
using FDCApp.Contracts.Enumerations;
using FDCApp.Contracts.Models.FormAnswers;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class Site : IBaseLocalModel
    {
        public Site()
        {
            Assets = new List<Asset>();
        }

        [PrimaryKey]
        public Guid UID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int AssetsCout { get; set; }
        public int Sequence { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public TankStorage TankStorage { get; set; }

        public DateTime? lastVisitDate { get; set; }
        public DateTime LastSitesSync { get; set; }
        public SyncStatus SyncStatus { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        [JsonProperty("forms")]
        public List<SiteInspectionForm> InspectionForms { get; set; }

        [Indexed]
        public SyncAction SyncAction { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<VisitSite> Visits { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<VisitForm> VisitForms { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Asset> Assets { get; set; }

        public Site Clone()
        {
            return (Site)MemberwiseClone();
        }
    }
}
