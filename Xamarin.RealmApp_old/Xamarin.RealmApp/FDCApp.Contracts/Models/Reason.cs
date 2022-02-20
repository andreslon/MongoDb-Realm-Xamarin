using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public class Reason
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
