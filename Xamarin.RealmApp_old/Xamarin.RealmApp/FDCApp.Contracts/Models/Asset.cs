using System;
using System.Collections.Generic;
using FDCApp.Contracts.Enumerations;
using FDCApp.Contracts.Models.FormAnswers;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class Asset : IBaseLocalModel
    {
        public Asset()
        {            
            OldId = "";
            IsValid = true;
            IsPeakAiEnabled = false;

            AssetCFValueMetrics = new List<AssetCFValueMetric>();
            AssetValueMetrics = new List<AssetValueMetric>();
        }

        [PrimaryKey]
        public Guid UID { get; set; }
        public string OldId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Class { get; set; }
        public int ClassSequence { get; set; }
        public string Type { get; set; }
        public Guid TypeId { get; set; }
        public string Code { get; set; }
        public int Sequence { get; set; }
        public double? Latitute { get; set; }
        public double? Longitude { get; set; }
        public string Directions { get; set; }
        public string ServiceAddress { get; set; }
        public string TownShipLocation { get; set; }
        public string CountryLocation { get; set; }
        public string State { get; set; }
        public string ApiNumber { get; set; }
        public string Product { get; set; }
        public DateTime? lastVisitDate { get; set; }
        public DateTime? lastPictureDate { get; set; }
        public int MetricsCount { get; set; }
        public SyncAction SyncAction { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public DomesticLocationData DomesticLocationData { get; set; }

        [JsonProperty("ticketsTemplate")]
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<TicketTemplateHeader> TicketDefaultsTemplate { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<VisitAsset> Visits { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<LastVisit> LastVisits { get; set; }        

        [JsonProperty("metrics")]
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AssetValueMetric> AssetValueMetrics { get; set; }        

        [JsonProperty("cfMetrics")]
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AssetCFValueMetric> AssetCFValueMetrics { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Note> Notes { get; set; }
                
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Ticket> Tickets { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<VisitForm> VisitForms { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AssetSection> Sections { get; set; }             
    }
}
