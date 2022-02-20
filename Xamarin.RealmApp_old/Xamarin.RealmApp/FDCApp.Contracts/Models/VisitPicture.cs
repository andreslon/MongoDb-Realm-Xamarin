using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class VisitPicture 
    {
        public VisitPicture()
        {            
            UploadStatus = SyncStatusLocal.New;

            StartDate = DateTime.Now.Date;
            StartTime = DateTime.MinValue.TimeOfDay;

            EndDate = DateTime.Now.Date;
            EndTime = DateTime.MinValue.TimeOfDay;
        }

        [PrimaryKey]
        public Guid Id { get; set; }

        public DateTime PictureDate { get; set; }
        public string PictureUrl { get; set; }
        public string PictureType { get; set; }
        public Guid VisitAssetId { get; set; }
        public bool PictureProcessed { get; set; }        
        public string IndexOn { get; set; }
        public string IndexOff { get; set; }
        public string Note { get; set; }

        public DateTime? StartDateTime
        {
            get
            {
                return StartDate + StartTime;
            }
        }

        public DateTime? EndDateTime
        {
            get
            {
                return EndDate + EndTime;
            }
        }

        #region Internal properties
        [JsonIgnore]
        public DateTime StartDate { get; set; }

        [JsonIgnore]
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public TimeSpan? StartTime { get; set; }

        [JsonIgnore]
        public TimeSpan? EndTime { get; set; }

        [JsonIgnore]
        public SyncStatusLocal UploadStatus { get; set; }

        [JsonIgnore]
        public Guid SiteId { get; set; }

        [JsonIgnore]
        public Guid RouteId { get; set; }
        #endregion

        public VisitPicture Clone()
        {
            return (VisitPicture)MemberwiseClone();
        }
    }
}