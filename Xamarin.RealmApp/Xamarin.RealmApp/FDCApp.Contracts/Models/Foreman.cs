using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class Foreman
    {
        public Foreman()
        {
        }

        public Guid UID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Tender> Tenders { get; set; }
    }
}
