using FDCApp.Contracts.Enumerations;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class SynchronizationDownloadMessage
    {
        public SynchronizationDownloadMessage()
        {
            Tenders = new List<Tender>();            
            TaskId = Guid.NewGuid();
        }

        public Guid TaskId { get; set; }

        public DownloadAction DownloadAction { get; set; }
        

        public List<Tender> Tenders { get; set; }        
        public Guid SelectedRouteId { get; set; }
    }
}
