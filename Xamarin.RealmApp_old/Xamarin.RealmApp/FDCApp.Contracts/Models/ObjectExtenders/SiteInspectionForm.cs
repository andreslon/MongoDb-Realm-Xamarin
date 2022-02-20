using FDCApp.Contracts.Core;
using SQLite;

namespace FDCApp.Contracts.Models
{
    public partial class SiteInspectionForm : PropertyClass
    {
        private bool _isSelected;

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
                RaisePropertyChanged(nameof(IsSelected));
            }
        }
    }
}