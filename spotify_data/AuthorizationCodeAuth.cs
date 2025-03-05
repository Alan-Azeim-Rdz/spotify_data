namespace spotify_data
{
    internal class AuthorizationCodeAuth
    {
        private string clientId;
        private string clientSecret;
        private string redirectUri;
        private object value;

        public AuthorizationCodeAuth(string clientId, string clientSecret, string redirectUri, object value)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.redirectUri = redirectUri;
            this.value = value;
        }
    }
}