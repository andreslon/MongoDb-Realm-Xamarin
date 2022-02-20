using System;
using System.Collections.Generic;
using FDCApp.Contracts.Constants;
using FDCApp.Contracts.Enumerations;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models.FormAnswers
{
    public partial class VisitForm
    {
        public string Description { get; set; }
        public string FormattedAnswersDate => LastUpdate.ToLocalTime().ToString(ConfigConstant.Display_DateTime_Format);

        [JsonIgnore]
        [ForeignKey(typeof(Site))]
        public Guid SiteId { get; set; }

        [JsonIgnore]
        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }
                
        [Indexed]
        public SyncAction SyncAction { get; set; }

        [JsonIgnore]
        public SyncStatusLocal SyncStatus { get; set; }

        public VisitForm Clone()
        {
            var result = (VisitForm)this.MemberwiseClone();
            result.Answers = new List<FormAnswer>();

            return result;
        }
    }
}