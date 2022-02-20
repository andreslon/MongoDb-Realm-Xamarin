using System;
using Newtonsoft.Json;

namespace FDCApp.Contracts.Models.Internal
{
    public class TokenData
    {
        private int _expiresIn;

        public string IdToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn
        {
            get
            {
                return this._expiresIn;
            }
            set
            {
                this._expiresIn = value;
                ExpirationDate = DateTimeOffset.UtcNow.AddSeconds(this._expiresIn);
            }
        }

        [JsonProperty("ext_expires_in")]
        public int ExtExpiresIn { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }
    }
}
