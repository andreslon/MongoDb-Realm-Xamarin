using System;
using FDCApp.Contracts.Constants;
using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class Site
    {
        [JsonIgnore]
        [ForeignKey(typeof(Route))]
        public Guid RouteUID { get; set; }

        [JsonIgnore]
        public DownloadStatus DownloadStatus { get; set; }

        [JsonIgnore]
        [Ignore]
        public Guid VisitSiteId { get; set; }

        [JsonIgnore]
        [Ignore]
        public string LastVisitDateLabel
        {
            get
            {
                return this.lastVisitDate == null ? "None" : ((DateTime)this.lastVisitDate).ToString(ConfigConstant.Display_Date_Format);
            }
            set
            {
                DateTime lastVisit;
                if (DateTime.TryParse(value, out lastVisit))
                    this.lastVisitDate = lastVisit;
                else
                    this.lastVisitDate = null;
            }
        }

        [JsonIgnore]
        [Ignore]
        public int Inconsistencies { get; set; }

        [JsonIgnore]
        public Guid UploadId { get; set; }
    }
}
