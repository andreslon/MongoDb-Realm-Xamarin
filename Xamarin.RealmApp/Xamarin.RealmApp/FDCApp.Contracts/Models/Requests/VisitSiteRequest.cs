using System;

namespace FDCApp.Contracts.Models.Requests
{
    public class VisitSiteRequest
    {
        public Guid OperatorId { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
