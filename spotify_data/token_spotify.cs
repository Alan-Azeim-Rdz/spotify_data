using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotify_data
{
    class token_spotify
    {
        private static string clientId = "aa5899baf44341aeacf52e8666bb2107";
        private static string clientSecret = "94345ca9d6e840108305808c1a04aa37";
        private static string redirectUri = "http://localhost:5000/callback";

        public static async Task<string> AuthenticateAsync()
        {
            var loginRequest = new LoginRequest(
                new Uri(redirectUri),
                clientId,
                LoginRequest.ResponseType.Code)
            {
                Scope = new List<string> { "user-read-playback-state", "user-modify-playback-state" }
            };

            var uri = loginRequest.ToUri();
            Process.Start(new ProcessStartInfo { FileName = uri.ToString(), UseShellExecute = true });



            //implementa el codigo de la track_album_id para la url
            MessageBox.Show("Por favor, ingresa el código de autorización de la URL:");
            string? code = Console.ReadLine(); // Pedimos al usuario que copie el código manualmente

            if (string.IsNullOrEmpty(code))
            {
                throw new Exception("No se proporcionó código de autorización.");
            }

            var tokenRequest = new AuthorizationCodeTokenRequest(clientId, clientSecret, code, new Uri(redirectUri));
            var oauth = new OAuthClient();
            var response = await oauth.RequestToken(tokenRequest);

            return response.AccessToken;
        }
    }
}
