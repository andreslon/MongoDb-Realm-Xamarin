using System.Collections.Generic;

namespace FDCApp.Contracts.Models
{
    public class AppVersion
    {
        public AppVersion()
        {
            Features = new List<string>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public bool ValidateVersion { get; set; }
        public string PreviewNumber { get; set; }
        public string PreviewApi { get; set; }
        public List<string> Features { get; set; }

        public string CurrentVersion { get; set; }
        public bool IsLatestVersion
        {
            get
            {
                return (Number == CurrentVersion);
            }
        }

        public bool IsPreviewVersion
        {
            get
            {
                return (PreviewNumber == CurrentVersion);
            }
        }
    }
}
