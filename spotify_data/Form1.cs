using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace spotify_data
{
    public partial class Form1 : Form
    {
        private string access_token;

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
            access_token = await token_spotify.AuthenticateAsync();
            if (string.IsNullOrEmpty(access_token))
            {
                MessageBox.Show("Error al autenticar con Spotify.");
                return;
            }
            if (e.RowIndex >= 0) // Verifica que no sea un encabezado
            {
                var selectedRow = DataViewShowData.Rows[e.RowIndex];

                // Asegúrate de que la celda no esté vacía y extrae el track_album_id
                string trackAlbumId = selectedRow.Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(trackAlbumId))
                {
                    await PlaySongAsync(trackAlbumId);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el Track Album ID.");
                }
            }
        }

        private async Task PlaySongAsync(string trackUri)
        {
            if (string.IsNullOrEmpty(access_token))
            {
                access_token = await token_spotify.AuthenticateAsync();
                if (string.IsNullOrEmpty(access_token))
                {
                    MessageBox.Show("No se pudo autenticar con Spotify.");
                    return;
                }
            }

            try
            {
                var spotify = new SpotifyClient(access_token);
                var request = new PlayerResumePlaybackRequest
                {
                    Uris = new List<string> { trackUri }
                };

                await spotify.Player.ResumePlayback(request);
                MessageBox.Show("Reproduciendo canción en Spotify.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reproducir la canción: " + ex.Message);
            }
        }

      


    }
}
