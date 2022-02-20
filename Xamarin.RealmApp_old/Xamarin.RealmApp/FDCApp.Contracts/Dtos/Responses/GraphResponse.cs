using System.Collections.Generic;

namespace FDCApp.Contracts.Dtos.Responses
{
    public class GraphResponse
    {        
        public List<object> BusinessPhones { get; set; }
        public string DisplayName { get; set; }
        public string GivenName { get; set; }
        public object JobTitle { get; set; }
        public object Mail { get; set; }
        public object MobilePhone { get; set; }
        public object OfficeLocation { get; set; }
        public object PreferredLanguage { get; set; }
        public string Surname { get; set; }
        public string UserPrincipalName { get; set; }
        public string Id { get; set; }  
    }   
}
