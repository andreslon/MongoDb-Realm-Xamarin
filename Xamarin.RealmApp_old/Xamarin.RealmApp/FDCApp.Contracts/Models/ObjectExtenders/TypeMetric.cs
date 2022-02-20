using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SQLite;

namespace FDCApp.Contracts.Models
{
    public partial class TypeMetric
    {
        private List<string> _applyToList;

        [JsonIgnore]
        public string CalculationUidsBlobbed { get; set; }
        public string RelatedItemsBlobbed { get; set; }
        

        [JsonIgnore]
        [Ignore]
        public List<string> ApplyToList
        {
            get
            {
                if (!this._applyToList.Any() && !string.IsNullOrEmpty(this.ApplyTo))
                {
                    this._applyToList = this.ApplyTo.ToUpper().Split(',').ToList();
                }

                return this._applyToList;
            }
        }
    }
}
