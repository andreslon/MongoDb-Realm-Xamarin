namespace FDCApp.Contracts.Models
{
    public class DomesticLocationTypeMetric : TypeMetric
    {
        public DomesticLocationTypeMetric()
        {
            isPreviousValue = false;
        }

        public bool isPreviousValue { get; set; }
    }
}