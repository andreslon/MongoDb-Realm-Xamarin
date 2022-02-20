using SQLite;
using System;

namespace FDCApp.Contracts.Models
{
    public enum ProductionMethod
    {
        Default = 0
    }

    public class Well : IBaseLocalModel, INewAsset
    {
        [Indexed]
        public Guid Id { get; set; }
        public string WellId { get; set; }
        public string Name { get; set; }
        public ProductionMethod ProductionMethod { get; set; }
        public bool IsOnCurrentRoute { get; set; }
        public string SomeoneElsesRoute { get; set; }
        public string LegacyId { get; set; }
        public string Api { get; set; }
        public string Directions { get; set; }
        public string Comments { get; set; }


        #region Internal properties
        [PrimaryKey, AutoIncrement]
        public Guid UID { get; set; }
        #endregion
    }
}
