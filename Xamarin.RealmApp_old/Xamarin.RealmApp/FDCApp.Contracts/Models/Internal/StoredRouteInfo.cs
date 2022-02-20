using SQLite;
using System;

namespace FDCApp.Contracts.Models.Internal
{
    public class StoredRouteInfo : IBaseLocalModel
    {
        public StoredRouteInfo()
        {
        }

        [PrimaryKey]
        public Guid UID { get; set; }
        public DateTime LastSyncDate { get; set; }
    }
}
