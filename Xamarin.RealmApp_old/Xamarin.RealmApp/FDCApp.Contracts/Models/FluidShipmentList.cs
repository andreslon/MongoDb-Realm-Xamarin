using FDCApp.Contracts.Enumerations;
using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class FluidShipmentList
    {
        [PrimaryKey]
        public Guid FluidshipAssocId { get; set; }

        public Guid BussinesAssocId { get; set; }
        public string BussinesAssocCode { get; set; }
        public string BussinesAssocDisplay { get; set; }
        public string BussinesAssocName { get; set; }
        
        public Guid BussinesAssocTypeId { get; set; }

        [Indexed]
        public ObjectStatus Status { get; set; }

        [Indexed]
        public string BussinesAssocType { get; set; }

        [Indexed]
        public Guid? AssetId { get; set; }

    }
}
