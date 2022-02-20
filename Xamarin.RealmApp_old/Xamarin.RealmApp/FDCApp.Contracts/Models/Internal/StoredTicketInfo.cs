using System;
namespace FDCApp.Contracts.Models.Internal
{
    public class StoredTicketInfo
    {
        public StoredTicketInfo()
        {
        }

        public Guid TicketUid { get; set; }
        public DateTime HaulDate { get; set; }
        public decimal Volume { get; set; }
        public string TypeGroup { get; set; }
    }
}
