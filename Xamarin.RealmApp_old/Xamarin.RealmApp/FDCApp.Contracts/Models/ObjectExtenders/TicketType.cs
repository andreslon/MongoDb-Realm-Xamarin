using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SQLite;

namespace FDCApp.Contracts.Models
{
    public partial class TicketType
    {
        public TicketType()
        {
            _assetTypeList = new List<string>();
            _productTypeList = new List<string>();
        }

        private List<string> _assetTypeList;
        private List<string> _productTypeList;

        [JsonIgnore]
        [Ignore]
        public bool IsTransferTicket
        {
            get
            {
                return this.GroupShort.ToLower().Contains("transfer");
            }
        }

        [JsonIgnore]
        [Ignore]
        public List<string> AssetTypeList
        {
            get
            {
                if (!this._assetTypeList.Any() && !string.IsNullOrEmpty(this.AssetType))
                {                    
                    this._assetTypeList = this.AssetType.Split(',').ToList();                    
                }

                return this._assetTypeList;
            }
        }

        [JsonIgnore]
        [Ignore]
        public List<string> ProductTypeList
        {
            get
            {
                if (!this._productTypeList.Any() && !string.IsNullOrEmpty(this.ProductType))
                {
                    this._productTypeList = this.ProductType.ToUpper().Split(',').ToList();
                }

                return this._productTypeList;
            }
        }
    }
}
