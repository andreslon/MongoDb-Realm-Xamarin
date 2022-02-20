using System;
namespace FDCApp.Contracts.Dtos.Responses
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string ApiToken { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
        public string EnertiaId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
    }
}
