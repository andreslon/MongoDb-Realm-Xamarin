using Newtonsoft.Json;
using Prism.Commands;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class MetricList : BaseNotifyClass
    {
        public MetricList()
        {
            MetricDependecy = new List<string>();
        }

        [PrimaryKey]
        public Guid Value { get; set; }
        public string Text { get; set; }
        public string ValueCode { get; set; }

        public string MetricDomainFormula { get; set; }
        public string MetricDomainParentFormula { get; set; }
        public string MetricDomainFilter { get; set; }

        [TextBlob(nameof(MetricDependecyBlobbed))]
        public List<string> MetricDependecy { get; set; }

        [TextBlob(nameof(MetricDomainCalcUidsBlobbed))]
        public List<string> MetricDomainCalcUids { get; set; }

        [Indexed]
        public Guid MetricUid { get; set; }

        [Indexed]
        public string MetricCode { get; set; }

        #region Internal properties

        public string MetricDependecyBlobbed { get; set; }

        [JsonIgnore]
        public string MetricDomainCalcUidsBlobbed { get; set; }

        [JsonIgnore]
        private bool _isSelected;

        [JsonIgnore]
        [Ignore]
        public bool IsSelected
        {
            get
            {
                return this._isSelected;
            }
            set
            {
                this._isSelected = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        [Ignore]
        public DelegateCommand SelectCommand => new DelegateCommand(Select);
        #endregion

        private void Select()
        {
            IsSelected = !IsSelected;
        }
    }
}
