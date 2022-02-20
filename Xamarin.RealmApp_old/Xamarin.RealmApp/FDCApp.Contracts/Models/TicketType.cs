using System;
using SQLite;

namespace FDCApp.Contracts.Models
{
    public partial class TicketType
    {
        [PrimaryKey]
        public Guid AssetTypeId { get; set; }
        public Guid ClassId { get; set; }
        public string Name { get; set; }
        public string GroupShort { get; set; }
        public string Group { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Status { get; set; }
        public int InnerColumns { get; set; }
        public string AssetType { get; set; }
        public string ProductType { get; set; }
    }
}                                   
