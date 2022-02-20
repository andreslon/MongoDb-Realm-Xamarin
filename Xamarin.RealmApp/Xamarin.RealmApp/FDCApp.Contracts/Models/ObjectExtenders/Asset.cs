using System;
using FDCApp.Contracts.Constants;
using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public partial class Asset
    {
        #region Internal properties
        [JsonIgnore]
        [ForeignKey(typeof(Site))]
        public Guid SiteId { get; set; }

        [JsonIgnore]
        public string TypeDescription { get; set; }

        [JsonIgnore]
        public bool ProductionMethodChanged { get; set; }

        [JsonIgnore]
        [Ignore]
        public Guid VisitSiteId { get; set; }

        [JsonIgnore]
        [Ignore]
        public Guid AssetVisitId { get; set; }

        [JsonIgnore]
        [Ignore]
        public bool IsEnable { get; set; }

        [JsonIgnore]
        [Ignore]
        public bool IsValid { get; set; }

        [JsonIgnore]
        [Ignore]
        public bool IsPeakAiEnabled { get; set; }

        [JsonIgnore]
        [Ignore]
        public string LastPictureDateLabel
        {
            get
            {
                string pictureDate = this.lastPictureDate == null ? "None" : ((DateTime)this.lastPictureDate).ToString(ConfigConstant.Display_Date_Format);
                return $"Last picture: {pictureDate}";
            }
        }

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
        public int AssetHeight
        {
            get
            {
                if (MetricsCount > 0)
                {
                    return (MetricsCount * 46) + 40;
                }
                else
                {
                    return 300;
                }
            }
        }

        [JsonIgnore]
        [Ignore]
        public AssetSubType AssetSubType
        {
            get
            {
                if (string.IsNullOrEmpty(Type))
                {
                    return AssetSubType.None;
                }

                switch (this.Type.ToLower())
                {
                    case "house gas":
                        return AssetSubType.Meter_Domestic;

                    case "tank hybrid":
                        return AssetSubType.Tank_Hybrid;

                    default:
                        return AssetSubType.None;
                }
            }
        }

        [JsonIgnore]
        [Ignore]
        public AssetType AssetType
        {
            get
            {
                switch (this.Class.ToLower())
                {
                    case "tank":
                        return AssetType.Tank;

                    case "meter":
                        return AssetType.Meter;

                    case "well":
                        return AssetType.Well;

                    case "zone":
                        return AssetType.Zone;

                    case "equipment":
                        return AssetType.Equipment;

                    default:
                        return AssetType.None;
                }
            }
        }
        #endregion  
    }
}
