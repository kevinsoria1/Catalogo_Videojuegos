using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient; // Necesario para guardar la compra

namespace Login1
{
    public partial class FormDetalles : Form
    {
        // --- DLL PARA BORDES Y MOVIMIENTO ---
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int nWidthEllipse, int nHeightEllipse);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Variables para la lógica de compra
        private int idJuego;
        private string usuarioActual;
        private bool esMio;
        private Button btnAccion; // Lo hacemos global para poder cambiarle el texto

        // CONSTRUCTOR ACTUALIZADO (Recibe más datos)
        public FormDetalles(string titulo, string desc, string ano, string genero, string precio, Image imagenJuego, int id, string usuario, bool yaLoTengo)
        {
            this.idJuego = id;
            this.usuarioActual = usuario;
            this.esMio = yaLoTengo;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(700, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(18, 18, 28);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            ConstruirInterfazModerna(titulo, desc, ano, genero, precio, imagenJuego);
        }

        private void ConstruirInterfazModerna(string titulo, string desc, string ano, string genero, string precio, Image img)
        {
            // 1. BARRA SUPERIOR
            Panel panelTop = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.Transparent };
            panelTop.MouseDown += (s, e) => { ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0); };
            this.Controls.Add(panelTop);

            Label btnCerrar = new Label { Text = "●", Location = new Point(660, 10), ForeColor = Color.FromArgb(255, 80, 80), Cursor = Cursors.Hand, AutoSize = true, Font = new Font("Segoe UI", 16) };
            btnCerrar.Click += (s, e) => this.Close();
            panelTop.Controls.Add(btnCerrar);

            // 2. IMAGEN
            PictureBox picCover = new PictureBox();
            picCover.Location = new Point(20, 50);
            picCover.Size = new Size(220, 320);
            picCover.SizeMode = PictureBoxSizeMode.StretchImage;
            if (img != null) picCover.Image = img;
            else picCover.BackColor = Color.FromArgb(40, 40, 60);

            Panel bordeImagen = new Panel { Location = new Point(18, 48), Size = new Size(224, 324), BackColor = Color.Cyan };
            this.Controls.Add(picCover); this.Controls.Add(bordeImagen); bordeImagen.SendToBack();

            // 3. DATOS
            Label lblTitulo = new Label { Text = titulo.ToUpper(), Location = new Point(260, 40), ForeColor = Color.White, Font = new Font("Segoe UI Black", 24, FontStyle.Bold), AutoSize = true, MaximumSize = new Size(400, 0) };
            this.Controls.Add(lblTitulo);

            Panel linea = new Panel { Location = new Point(265, lblTitulo.Bottom + 5), Size = new Size(100, 3), BackColor = Color.Magenta };
            this.Controls.Add(linea);

            Label lblTags = new Label { Text = $"{ano}  •  {genero}", Location = new Point(265, linea.Bottom + 10), ForeColor = Color.Gray, Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true };
            this.Controls.Add(lblTags);

            Label lblPrecio = new Label { Text = precio, Location = new Point(580, linea.Bottom + 5), ForeColor = Color.Cyan, Font = new Font("Segoe UI", 14, FontStyle.Bold), AutoSize = true, TextAlign = ContentAlignment.MiddleRight };
            this.Controls.Add(lblPrecio);

            // 4. DESCRIPCIÓN
            RichTextBox rtbDesc = new RichTextBox { Text = desc, Location = new Point(260, 140), Size = new Size(400, 150), BackColor = Color.FromArgb(25, 25, 35), ForeColor = Color.LightGray, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.None, ReadOnly = true };
            this.Controls.Add(rtbDesc);

            // 5. BOTÓN INTELIGENTE (JUGAR O COMPRAR)
            btnAccion = new Button
            {
                Size = new Size(400, 50),
                Location = new Point(260, 320),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnAccion.FlatAppearance.BorderSize = 0;

            // CONFIGURAR ESTADO INICIAL
            ActualizarEstadoBoton();

            // EVENTO CLIC ÚNICO (Deriva a Jugar o Comprar según el estado)
            btnAccion.Click += (s, e) => {
                if (esMio) AccionJugar(titulo);
                else AccionComprar(titulo);
            };

            this.Controls.Add(btnAccion);
        }

        private void ActualizarEstadoBoton()
        {
            if (esMio)
            {
                btnAccion.Text = "▶ JUGAR AHORA";
                btnAccion.BackColor = Color.FromArgb(255, 193, 7); // Amarillo/Naranja Gamer
                btnAccion.ForeColor = Color.Black;
            }
            else
            {
                btnAccion.Text = "COMPRAR AHORA";
                btnAccion.BackColor = Color.FromArgb(0, 180, 160); // Verde Compra
                btnAccion.ForeColor = Color.White;
            }
        }

        private void AccionJugar(string titulo)
        {
            MessageBox.Show($"Iniciando {titulo}...\n¡Que te diviertas!", "FIPPY GAMES - LANZADOR");
        }

        private void AccionComprar(string titulo)
        {
            if (MessageBox.Show($"¿Confirmar compra de {titulo}?", "Checkout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO biblioteca (usuario_id, juego_id) VALUES (@u, @j)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@u", usuarioActual);
                        cmd.Parameters.AddWithValue("@j", idJuego);
                        cmd.ExecuteNonQuery();

                        // ÉXITO: Cambiamos el estado visual al instante
                        esMio = true;
                        ActualizarEstadoBoton();

                        MessageBox.Show("¡Compra realizada con éxito!\nAhora el botón ha cambiado a JUGAR.", "¡GRACIAS!");

                        // Opcional: Cerrar ventana tras comprar
                        // this.Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error en la compra: " + ex.Message);
                    }
                }
            }
        }
    }
}