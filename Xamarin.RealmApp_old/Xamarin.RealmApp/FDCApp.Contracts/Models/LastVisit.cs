using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace FDCApp.Contracts.Models
{
    public class LastVisit
    {
        public LastVisit()
        {
            IsInternal = false;
        }

        private Guid _visitAssetId;

        [PrimaryKey, AutoIncrement]
        public int LocaltId { get; set; }

        [Indexed]
        public Guid VisitAssetId
        {
            get
            {
                return _visitAssetId;
            }
            set
            {
                if (value == Guid.Empty)
                {
                    value = Guid.NewGuid();
                }
                this._visitAssetId = value;
            }
        }
        public Guid VisitSiteId { get; set; }

        [Indexed]
        public DateTime VisitDate { get; set; }
        public bool IsInternal { get; set; }
        public string TankHeight { get; set; }

        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }
    }
}
