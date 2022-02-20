using System;
using Newtonsoft.Json;

namespace FDCApp.Contracts.Models
{
    public class InspectionType
    {
        public Guid UID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public bool IsSelected { get; set; }
    }
}
