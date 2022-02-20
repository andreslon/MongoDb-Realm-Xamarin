using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class ForemanTank
    {
        [PrimaryKey]
        public Guid UID { get; set; }
        public string Name { get; set; }
    }
}
