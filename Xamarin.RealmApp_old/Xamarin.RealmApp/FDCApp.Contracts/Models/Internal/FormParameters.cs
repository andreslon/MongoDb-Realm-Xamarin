using System;
using FDCApp.Contracts.Enumerations;

namespace FDCApp.Contracts.Models.Internal
{
    public class FormParameters
    {
        public Guid FormTypeId { get; set; }
        public Guid SiteId { get; set; }
        public Guid? AssetId { get; set; }
        public Guid? ParentId { get; set; }
        public ObjectAction Action { get; set; }
        public Guid? VisitFormId { get; set; }
    }
}
