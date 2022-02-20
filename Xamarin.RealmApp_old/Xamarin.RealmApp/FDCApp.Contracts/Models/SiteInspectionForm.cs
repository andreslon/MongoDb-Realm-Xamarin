using System;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class SiteInspectionForm : IBaseLocalModel
    {
        public SiteInspectionForm()
        {
            UID = Guid.NewGuid();
        }

        [PrimaryKey]
        public Guid UID { get; set; }

        [Indexed]
        [ForeignKey(typeof(Site))]
        public Guid SiteId { get; set; }

        [JsonProperty("id")]
        public Guid FormId { get; set; }
        public string FormCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int Status { get; set; }
    }
}
