using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class SiteInconsistency
    {
        public SiteInconsistency()
        {
            Inconsistencies = new List<MetricInconsistency>();
        }

        public Guid SiteId { get; set; }
        public Guid UserId { get; set; }
        public Guid UploadId { get; set; }
        public string DeviceId { get; set; }
        public DateTime UploadTimestamp { get; set; }
        public List<MetricInconsistency> Inconsistencies { get; set; }
    }
}
