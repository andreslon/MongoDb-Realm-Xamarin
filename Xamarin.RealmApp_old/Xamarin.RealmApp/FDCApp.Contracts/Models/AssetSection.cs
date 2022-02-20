using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FDCApp.Contracts.Models
{
    public class AssetSection
    {
        [PrimaryKey]
        public Guid SectionId { get; set; }

        [ForeignKey(typeof(Asset))]
        public Guid AssetId { get; set; }

        public int SectionNumber { get; set; }
        public int Columns { get; set; }
    }
}
