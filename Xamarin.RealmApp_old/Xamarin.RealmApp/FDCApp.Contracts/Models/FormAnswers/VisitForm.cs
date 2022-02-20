using System;
using System.Collections.Generic;
using FDCApp.Contracts.Enumerations;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;

namespace FDCApp.Contracts.Models.FormAnswers
{
    public partial class VisitForm : IBaseLocalModel
    {        
        public VisitForm()
        {
            Answers = new List<FormAnswer>();
            SyncStatus = SyncStatusLocal.None;
            WasEdited = false;
        }

        [JsonProperty("VisitFormId")]
        [PrimaryKey]
        public Guid UID { get; set; }

        [Indexed]
        public Guid VisitSiteId { get; set; }        

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FormAnswer> Answers { get; set; }

        [Indexed]
        public Guid VisitAssetId { get; set; }

        public Guid FormId { get; set; }
        public Guid OperatorId { get; set; }
        public DateTime DateOfAnswers { get; set; }
        public int Status { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? PreverId { get; set; }
        public DateTime LastUpdate { get; set; }

        [JsonIgnore]
        public bool WasEdited { get; set; }
    }
}