using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models.FormQuestions
{
    public partial class Form : IBaseLocalModel
    {
        public Form()
        {
        }

        [PrimaryKey]
        [JsonProperty("id")]
        public Guid UID { get; set; }
        public string FormCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleteable { get; set; }
        public bool IsEditable { get; set; }
        public string ListViewType { get; set; }
        public string NewButtonLabel { get; set; }
        public bool? IsStandalone { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<FormSection> Sections { get; set; }

        [ForeignKey(typeof(Site))]
        public Guid SiteId { get; set; }
    }
}
