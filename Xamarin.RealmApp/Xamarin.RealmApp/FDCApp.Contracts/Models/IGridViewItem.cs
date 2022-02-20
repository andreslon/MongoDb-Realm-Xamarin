namespace FDCApp.Contracts.Models
{
    public interface IGridViewItem
    {
        int ColumnSpan { get; set; }
        int RowSpan { get; set; }
        int? Column { get; set; }
        int? Row { get; set; }
    }
}