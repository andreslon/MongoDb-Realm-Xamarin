using System;
namespace FDCApp.Contracts.Models
{
    public class User
    {
        public User()
        {
        }

        public Guid UID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }
        public string PhotoUrl { get; set; }

    }
}
