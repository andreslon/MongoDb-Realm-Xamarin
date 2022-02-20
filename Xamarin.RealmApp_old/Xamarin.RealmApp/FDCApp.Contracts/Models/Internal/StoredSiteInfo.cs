using FDCApp.Contracts.Enumerations;
using SQLite;
using System;

namespace FDCApp.Contracts.Models.Internal
{
    public class StoredSiteInfo : IBaseLocalModel
    {
        public StoredSiteInfo()
        {
            IsDownloading = true;
        }

        [Indexed]
        public Guid RouteId { get; set; }

        [PrimaryKey]
        public Guid UID { get; set; }

        public DateTime LastSyncDate { get; set; }
        public DateTime? LastVisitDate { get; set; }
        public DownloadStatus DownloadStatus { get; set; }

        #region Internal
        [Ignore]        
        public bool IsDownloading { get; set; }
        #endregion
    }
}
