using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Login1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private string EncriptarPass(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

    
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

        
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, introduce usuario y contraseña.");
                return;
            }

            DatabaseConnection db = new DatabaseConnection();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    
                    string query = "SELECT Contrasena, rol, estado FROM usuarios WHERE NombreUsuario = @u";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", usuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPass = reader["Contrasena"].ToString();
                            string rol = reader["rol"].ToString(); // "Administrador" o "Usuario Nominal" [cite: 29]
                            string estado = reader["estado"].ToString(); // Activo o Baneado [cite: 31]
                            string passEncriptada = EncriptarPass(password);

                            if (estado == "Baneado")
                            {
                                MessageBox.Show("Acceso denegado: Su cuenta ha sido bloqueada.");
                                return;
                            }

                            // Validación de credenciales
                            if (dbPass == passEncriptada)
                            {
                               
                                if (rol == "Admin")
                                {
                                   
                                    MessageBox.Show($"Bienvenido Administrador: {usuario}");
                                    Form2 f2 = new Form2(usuario, "Admin");
                                    f2.Show();
                                }
                                else
                                {
                                  
                                    MessageBox.Show($"Bienvenido Usuario: {usuario}");
                                    Form2 f2 = new Form2(usuario, "Nominal");
                                    f2.Show();
                                }
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Contraseña incorrecta.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }
        }

  
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Completa los campos para registrarte.");
                return;
            }

            string passEncriptada = EncriptarPass(password);
            DatabaseConnection db = new DatabaseConnection();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                   
                    string query = "INSERT INTO usuarios (NombreUsuario, Contrasena, email, rol, estado) " +
                                   "VALUES (@u, @p, @e, 'Nominal', 'Activo')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", usuario);
                    cmd.Parameters.AddWithValue("@p", passEncriptada);
                    cmd.Parameters.AddWithValue("@e", usuario + "@correo.com"); // Requisito campo email 

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Usuario registrado con éxito!");

                    textBox1.Clear();
                    textBox2.Clear();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) MessageBox.Show("El nombre de usuario ya existe.");
                    else MessageBox.Show("Error de base de datos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}