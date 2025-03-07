using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace spotify_data
{
    public partial class Form1 : Form
    {
        private string access_token;
        private SpotifyClient spotify;

        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnSelect_Click(object sender, EventArgs e)
        {
           

            // abre un dialogo para seleccionar un archivo de tipo .csv para dividir la informacion por columnas y filas tomando las columnas como los primeros datos de la fila 0
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files|*.csv";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // lee el archivo seleccionado
                string[] lines = File.ReadAllLines(ofd.FileName);

                // divide la informacion por columnas y filas, tomando las columnas como los primeros datos de la fila 0 y las comas dentro de las comillas como parte de la informacion
                string[][] values = new string[lines.Length][];
                for (int i = 0; i < lines.Length; i++)
                {
                    values[i] = lines[i].Split(',');
                }


                // muestra la informacion en el datagridview
                DataViewShowData.ColumnCount = values[0].Length;
                for (int i = 0; i < values.Length; i++)
                {
                    DataViewShowData.Rows.Add(values[i]);
                }
            }

        }
        private async void DataViewShowData_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita que se procese el encabezado

            var selectedRow = DataViewShowData.Rows[e.RowIndex];
            string trackAlbumId = selectedRow.Cells[0].Value?.ToString();

            if (string.IsNullOrEmpty(trackAlbumId))
            {
                MessageBox.Show("No se pudo obtener el Track Album ID.");
                return;
            }

            // Autenticación con Spotify antes de intentar reproducir
            await AuthenticateSpotifyAsync();
            await PlaySongAsync(trackAlbumId);
        }

        private async Task AuthenticateSpotifyAsync()
        {
            if (!string.IsNullOrEmpty(access_token)) return;

            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest("f5a1692a92bd4cfcb9dc151a361de523", "6841f1e4963c4c1bb5f2a2fda12792f9");

            var response = await new OAuthClient(config).RequestToken(request);
            access_token = response.AccessToken;
            spotify = new SpotifyClient(access_token);
        }

        private async Task PlaySongAsync(string trackUri)
        {
            try
            {
                if (spotify == null)
                {
                    MessageBox.Show("No se pudo autenticar con Spotify.");
                    return;
                }

                // En lugar de reanudar la reproducción, solo abrimos la canción en Spotify
                var songUrl = $"https://open.spotify.com/track/{trackUri}";

                // Abre el enlace en el navegador por defecto
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = songUrl,
                    UseShellExecute = true
                });

                MessageBox.Show("Abriendo canción en Spotify.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la canción: " + ex.Message);
            }
        }

    }
}
