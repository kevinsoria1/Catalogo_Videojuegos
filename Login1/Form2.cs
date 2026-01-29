using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace Login1
{
    public partial class Form2 : Form
    {
        // --- 1. DLL IMPORTS (Movimiento ventana) ---
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // --- 2. VARIABLES GLOBALES ---
        private bool esCierreDeSesion = false;
        private string usuarioLogueado, rolLogueado;

        // PANELES
        private Panel panelContenedorAdmin;
        private Panel subPanelUsuarios;
        private Panel subPanelJuegos;
        private FlowLayoutPanel flowCatalogo;

        // ADMIN USUARIOS
        private string usuarioOriginalParaEditar = null;
        private DataGridView tablaUsuarios;
        private TextBox txtNuevoUser, txtNuevoPass, txtEmail, txtBuscarUser;
        private ComboBox comboRol, comboEstado;

        // ADMIN JUEGOS
        private int idJuegoEditando = -1;
        private DataGridView tablaJuegos;
        private TextBox txtJuegoTitulo, txtJuegoPrecio, txtJuegoFab, txtJuegoAnio, txtJuegoCat, txtJuegoDesc;
        private CheckBox checkJuegoVisible;
        private PictureBox picJuegoAdmin;

        // --- 3. CONSTRUCTOR ---
        public Form2() : this("ADMIN", "Admin") { }

        public Form2(string usuario, string rol)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;
            this.rolLogueado = rol;

            ConfigurarEventosExtra();
            ConfigurarInterfazCompleta();

            // Cargar el catálogo completo al entrar
            CargarEscaparate("TODO");
        }

        // --- 4. CONFIGURACIÓN VISUAL ---
        private void ConfigurarInterfazCompleta()
        {
            // A. BOTÓN PERFIL
            if (this.btnUsuario != null)
            {
                this.btnUsuario.Text = "👤 " + usuarioLogueado;
                bool esAdmin = rolLogueado.Equals("Admin", StringComparison.OrdinalIgnoreCase);
                this.btnUsuario.Visible = esAdmin;
                this.btnUsuario.Click -= MostrarPanelAdmin_Click;
                if (esAdmin) this.btnUsuario.Click += MostrarPanelAdmin_Click;
            }

            // NAVEGACIÓN
            if (this.btnDestacados != null) this.btnDestacados.Click += (s, e) => { MostrarHome(); CargarEscaparate("TODO"); };
            if (this.btnTienda != null) this.btnTienda.Click += (s, e) => { MostrarHome(); CargarEscaparate("TODO"); };
            if (this.btnMisJuegos != null) this.btnMisJuegos.Click += (s, e) => { MostrarHome(); CargarEscaparate("MIS_JUEGOS"); };

            // === BARRA DE FILTROS ===
            Panel panelFiltros = new Panel();
            panelFiltros.Size = new Size(780, 40);
            panelFiltros.Location = new Point(220, 80);
            panelFiltros.BackColor = Color.FromArgb(25, 20, 40);
            this.Controls.Add(panelFiltros);

            TextBox txtBuscarJuego = new TextBox();
            txtBuscarJuego.PlaceholderText = "🔍 Buscar juego...";
            txtBuscarJuego.Size = new Size(200, 25);
            txtBuscarJuego.Location = new Point(20, 8);
            txtBuscarJuego.BackColor = Color.FromArgb(40, 40, 60);
            txtBuscarJuego.ForeColor = Color.White;
            txtBuscarJuego.BorderStyle = BorderStyle.FixedSingle;
            panelFiltros.Controls.Add(txtBuscarJuego);

            ComboBox comboCategoria = new ComboBox();
            comboCategoria.Items.AddRange(new string[] { "Todas", "RPG", "Deportes", "Accion", "Aventura", "Estrategia" });
            comboCategoria.SelectedIndex = 0;
            comboCategoria.Size = new Size(120, 25);
            comboCategoria.Location = new Point(240, 8);
            comboCategoria.FlatStyle = FlatStyle.Flat;
            comboCategoria.BackColor = Color.FromArgb(40, 40, 60);
            comboCategoria.ForeColor = Color.White;
            panelFiltros.Controls.Add(comboCategoria);

            // Eventos de filtro
            txtBuscarJuego.KeyUp += (s, e) => CargarEscaparate("FILTRO", txtBuscarJuego.Text, comboCategoria.SelectedItem.ToString());
            comboCategoria.SelectedIndexChanged += (s, e) => CargarEscaparate("FILTRO", txtBuscarJuego.Text, comboCategoria.SelectedItem.ToString());

            // ESCAPARATE
            if (flowCatalogo == null)
            {
                flowCatalogo = new FlowLayoutPanel();
                flowCatalogo.Location = new Point(220, 125);
                flowCatalogo.Size = new Size(780, 475);
                flowCatalogo.AutoScroll = true;
                flowCatalogo.BackColor = Color.FromArgb(20, 20, 35);
                flowCatalogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                this.Controls.Add(flowCatalogo);
            }
            flowCatalogo.BringToFront();

            // PANEL ADMIN
            CrearPanelAdmin();
        }

        private void MostrarPanelAdmin_Click(object sender, EventArgs e) { MostrarAdmin(); }

        // --- 5. LÓGICA DEL ESCAPARATE ---
        private void CargarEscaparate(string modo, string busqueda = "", string categoria = "Todas")
        {
            flowCatalogo.Controls.Clear();
            DatabaseConnection db = new DatabaseConnection();
            using (var conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "";

                    if (modo == "MIS_JUEGOS")
                    {
                        // IMPORTANTE: Añadimos ", 1 as loTengo" para que no falle al leer esa columna después
                        sql = "SELECT v.id_juego, v.titulo, v.precio, v.imagen, v.descripcion, v.anio, v.categoria, 1 as loTengo FROM videojuegos v INNER JOIN biblioteca b ON v.id_juego = b.juego_id WHERE b.usuario_id = @u";
                    }
                    else
                    {
                        // Subconsulta para saber si lo tengo (1 o 0)
                        sql = @"SELECT id_juego, titulo, precio, imagen, descripcion, anio, categoria, 
                                (SELECT COUNT(*) FROM biblioteca b WHERE b.juego_id = v.id_juego AND b.usuario_id = @u) as loTengo 
                                FROM videojuegos v WHERE visible = 1";

                        if (!string.IsNullOrEmpty(busqueda)) sql += " AND titulo LIKE @busqueda";
                        if (categoria != "Todas" && !string.IsNullOrEmpty(categoria)) sql += " AND categoria = @cat";
                    }

                    var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", usuarioLogueado);
                    if (!string.IsNullOrEmpty(busqueda)) cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");
                    if (categoria != "Todas") cmd.Parameters.AddWithValue("@cat", categoria);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] img = reader["imagen"] != DBNull.Value ? (byte[])reader["imagen"] : null;

                        string desc = reader["descripcion"] != DBNull.Value ? reader["descripcion"].ToString() : "Sin descripción";
                        string anio = reader["anio"] != DBNull.Value ? reader["anio"].ToString() : "N/A";
                        string cat = reader["categoria"] != DBNull.Value ? reader["categoria"].ToString() : "General";
                        bool yaLoTengo = Convert.ToInt32(reader["loTengo"]) > 0;

                        AgregarTarjetaJuego(
                            reader["titulo"].ToString(),
                            reader["precio"].ToString(),
                            img,
                            Convert.ToInt32(reader["id_juego"]),
                            yaLoTengo,
                            desc,
                            anio,
                            cat
                        );
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error cargando juegos: " + ex.Message); }
            }
        }

        private void AgregarTarjetaJuego(string titulo, string precio, byte[] imgData, int idJuego, bool esMio, string desc, string anio, string cat)
        {
            Panel card = new Panel() { Size = new Size(160, 240), BackColor = Color.FromArgb(40, 40, 60), Margin = new Padding(15) };

            PictureBox pic = new PictureBox() { Size = new Size(160, 180), Location = new Point(0, 0), SizeMode = PictureBoxSizeMode.StretchImage, Cursor = Cursors.Hand };
            if (imgData != null) using (var ms = new MemoryStream(imgData)) pic.Image = Image.FromStream(ms);
            else pic.BackColor = Color.Gray;

            Label lblT = new Label() { Text = titulo, ForeColor = Color.White, Font = new Font("Segoe UI", 9, FontStyle.Bold), Location = new Point(5, 185), AutoSize = true, Cursor = Cursors.Hand };

            string textoPrecio = esMio ? "EN PROPIEDAD" : precio + " €";
            Color colorTexto = esMio ? Color.Lime : Color.Cyan;
            Label lblP = new Label() { Text = textoPrecio, ForeColor = colorTexto, Font = new Font("Segoe UI", 9), Location = new Point(5, 210), Cursor = Cursors.Hand };

            // EVENTO CLIC ÚNICO: Abre la ficha técnica
            EventHandler mostrarDetalles = (s, e) => {
                FormDetalles f = new FormDetalles(
                    titulo,
                    desc,
                    anio,
                    cat,
                    precio + " €",
                    pic.Image,
                    idJuego,
                    usuarioLogueado,
                    esMio
                );
                f.ShowDialog();
                // Al volver, recargamos por si compró algo
                CargarEscaparate("TODO");
            };

            pic.Click += mostrarDetalles;
            lblT.Click += mostrarDetalles;
            lblP.Click += mostrarDetalles;
            card.Click += mostrarDetalles;

            // Añadimos controles (SIN BOTONES PEQUEÑOS)
            card.Controls.AddRange(new Control[] { pic, lblT, lblP });
            flowCatalogo.Controls.Add(card);
        }

        // --- 6. PANEL ADMIN Y PESTAÑAS ---
        private void CrearPanelAdmin()
        {
            Color colorFondo = Color.FromArgb(15, 15, 30);
            panelContenedorAdmin = new Panel() { Size = new Size(780, 520), Location = new Point(220, 80), BackColor = colorFondo, Visible = false, Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
            this.Controls.Add(panelContenedorAdmin);

            Button btnTabUser = new Button() { Text = "👥 GESTIÓN USUARIOS", Bounds = new Rectangle(0, 0, 390, 40), FlatStyle = FlatStyle.Flat, ForeColor = Color.White, BackColor = Color.FromArgb(40, 40, 60) };
            Button btnTabGame = new Button() { Text = "🎮 GESTIÓN JUEGOS", Bounds = new Rectangle(390, 0, 390, 40), FlatStyle = FlatStyle.Flat, ForeColor = Color.White, BackColor = Color.FromArgb(20, 20, 40) };
            panelContenedorAdmin.Controls.AddRange(new Control[] { btnTabUser, btnTabGame });

            btnTabUser.Click += (s, e) => { subPanelUsuarios.Visible = true; subPanelJuegos.Visible = false; btnTabUser.BackColor = Color.FromArgb(40, 40, 60); btnTabGame.BackColor = Color.FromArgb(20, 20, 40); };
            btnTabGame.Click += (s, e) => { subPanelUsuarios.Visible = false; subPanelJuegos.Visible = true; btnTabGame.BackColor = Color.FromArgb(40, 40, 60); btnTabUser.BackColor = Color.FromArgb(20, 20, 40); CargarGridJuegos(); };

            // PANELES INTERNOS
            subPanelUsuarios = new Panel() { Bounds = new Rectangle(0, 40, 780, 480), Visible = true };
            panelContenedorAdmin.Controls.Add(subPanelUsuarios);
            GenerarControlesUsuarios(subPanelUsuarios);

            subPanelJuegos = new Panel() { Bounds = new Rectangle(0, 40, 780, 480), Visible = false };
            panelContenedorAdmin.Controls.Add(subPanelJuegos);
            GenerarControlesJuegos(subPanelJuegos);
        }

        // --- 7. CRUD USUARIOS ---
        // --- SUSTITUYE ESTE MÉTODO EN TU Form2.cs ---

        private void GenerarControlesUsuarios(Panel p)
        {
            // BUSCADOR
            txtBuscarUser = CrearInput(30, 25, 250, "🔍 Buscar...", p);
            txtBuscarUser.ForeColor = Color.Cyan;
            txtBuscarUser.TextChanged += (s, e) => { (tablaUsuarios.DataSource as DataTable).DefaultView.RowFilter = $"NombreUsuario LIKE '%{txtBuscarUser.Text}%'"; };

            // INPUTS
            txtNuevoUser = CrearInput(30, 70, 110, "Usuario", p);
            txtNuevoPass = CrearInput(150, 70, 110, "Pass", p); txtNuevoPass.PasswordChar = '•';
            txtEmail = CrearInput(270, 70, 150, "Email", p);

            // COMBOS
            comboRol = new ComboBox() { Location = new Point(430, 70), Width = 90, BackColor = Color.FromArgb(30, 30, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            comboRol.Items.AddRange(new string[] { "Admin", "Nominal" });

            comboEstado = new ComboBox() { Location = new Point(530, 70), Width = 90, BackColor = Color.FromArgb(30, 30, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            comboEstado.Items.AddRange(new string[] { "Activo", "Baneado" });

            p.Controls.AddRange(new Control[] { comboRol, comboEstado });

            // TABLA
            tablaUsuarios = CrearGrid(30, 110, 590, 360, p);

            // --- LÓGICA DE SELECCIÓN (PROTECCIÓN VISUAL) ---
            tablaUsuarios.CellClick += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    var row = tablaUsuarios.Rows[e.RowIndex];
                    usuarioOriginalParaEditar = row.Cells["NombreUsuario"].Value.ToString();

                    // Rellenar campos
                    txtNuevoUser.Text = usuarioOriginalParaEditar;
                    txtEmail.Text = row.Cells["email"].Value.ToString();
                    comboRol.SelectedItem = row.Cells["rol"].Value.ToString();
                    comboEstado.SelectedItem = row.Cells["estado"].Value.ToString();

                    // >>> PROTECCIÓN VISUAL <<<
                    // Si seleccionamos al "admin", bloqueamos cambiar su nombre, rol o estado.
                    bool esElJefe = (usuarioOriginalParaEditar.ToLower() == "admin");

                    txtNuevoUser.Enabled = !esElJefe;  // No puedes cambiarle el nombre
                    comboRol.Enabled = !esElJefe;      // No puedes quitarle el Admin
                    comboEstado.Enabled = !esElJefe;   // No puedes banearlo

                    if (esElJefe)
                        txtNuevoUser.BackColor = Color.DarkRed; // Aviso visual
                    else
                        txtNuevoUser.BackColor = Color.FromArgb(30, 30, 50);
                }
            };

            // BOTÓN AÑADIR
            CrearBoton("💾 AÑADIR", 640, 110, Color.Cyan, p, (s, e) => {
                // No dejamos crear otro usuario que se llame admin
                if (txtNuevoUser.Text.ToLower() == "admin") { MessageBox.Show("No puedes clonar al Jefe."); return; }

                string sql = "INSERT INTO usuarios (NombreUsuario, Contrasena, email, rol, estado) VALUES (@u, SHA2(@p,256), @e, @r, @s)";
                EjecutarAccionUser(sql);
            });

            // BOTÓN EDITAR (PROTEGIDO)
            CrearBoton("✏️ EDITAR", 640, 160, Color.Magenta, p, (s, e) => {
                // 1. Protección: Nadie puede editar el nombre del SuperAdmin
                if (usuarioOriginalParaEditar.ToLower() == "admin")
                {
                    // Solo permitimos cambiar contraseña o email, pero NUNCA el Rol ni el Nombre
                    if (txtNuevoUser.Text.ToLower() != "admin") { MessageBox.Show("⛔ ¡No puedes cambiar el nombre del SuperAdmin!"); return; }
                    if (comboRol.SelectedItem.ToString() != "Admin") { MessageBox.Show("⛔ ¡No puedes degradar al SuperAdmin!"); return; }
                    if (comboEstado.SelectedItem.ToString() != "Activo") { MessageBox.Show("⛔ ¡No puedes banear al SuperAdmin!"); return; }
                }

                string sql = "UPDATE usuarios SET NombreUsuario=@u, email=@e, rol=@r, estado=@s WHERE NombreUsuario=@old";
                if (!string.IsNullOrEmpty(txtNuevoPass.Text)) sql = sql.Replace("WHERE", ", Contrasena=SHA2(@p,256) WHERE");
                EjecutarAccionUser(sql);
            });

            // BOTÓN BORRAR (PROTEGIDO)
            CrearBoton("🗑️ BORRAR", 640, 210, Color.Red, p, (s, e) => {
                if (usuarioOriginalParaEditar != null)
                {
                    // >>> PROTECCIÓN SUPREMA <<<
                    if (usuarioOriginalParaEditar.ToLower() == "admin")
                    {
                        MessageBox.Show("⛔ ACCESO DENEGADO\n\nEl usuario 'admin' es el SuperAdmin y no puede ser eliminado.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Cortamos la ejecución aquí
                    }

                    // Protección Extra: No te puedes borrar a ti mismo si estás logueado
                    if (usuarioOriginalParaEditar == usuarioLogueado)
                    {
                        MessageBox.Show("No puedes auto-eliminarte mientras estás conectado.");
                        return;
                    }

                    EjecutarQuerySegura("DELETE FROM usuarios WHERE NombreUsuario=@u", new MySqlParameter[] { new MySqlParameter("@u", usuarioOriginalParaEditar) }, null);
                    CargarUsuarios(); LimpiarUser();
                }
            });

            CargarUsuarios();
        }

        private void EjecutarAccionUser(string sql)
        {
            try
            {
                var p = new MySqlParameter[] {
                    new MySqlParameter("@u", txtNuevoUser.Text), new MySqlParameter("@p", txtNuevoPass.Text),
                    new MySqlParameter("@e", txtEmail.Text), new MySqlParameter("@r", comboRol.SelectedItem),
                    new MySqlParameter("@s", comboEstado.SelectedItem), new MySqlParameter("@old", usuarioOriginalParaEditar)
                };
                EjecutarQuerySegura(sql, p, null); CargarUsuarios(); LimpiarUser();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- 8. CRUD JUEGOS ---
        private void GenerarControlesJuegos(Panel p)
        {
            txtJuegoTitulo = CrearInput(30, 20, 200, "Título", p);
            txtJuegoCat = CrearInput(240, 20, 120, "Categoría", p);
            txtJuegoPrecio = CrearInput(370, 20, 80, "Precio", p);
            txtJuegoFab = CrearInput(30, 60, 150, "Fabricante", p);
            txtJuegoAnio = CrearInput(190, 60, 80, "Año", p);
            checkJuegoVisible = new CheckBox() { Text = "Visible", Location = new Point(290, 60), ForeColor = Color.White, Checked = true };
            p.Controls.Add(checkJuegoVisible);

            txtJuegoDesc = CrearInput(30, 100, 440, "Descripción", p);
            picJuegoAdmin = new PictureBox() { Location = new Point(480, 20), Size = new Size(100, 100), SizeMode = PictureBoxSizeMode.StretchImage, BorderStyle = BorderStyle.FixedSingle };
            p.Controls.Add(picJuegoAdmin);

            Button btnFoto = CrearBoton("📷 FOTO", 480, 130, Color.Orange, p, (s, e) => {
                OpenFileDialog op = new OpenFileDialog() { Filter = "Imgs|*.jpg;*.png" };
                if (op.ShowDialog() == DialogResult.OK) picJuegoAdmin.Image = Image.FromFile(op.FileName);
            });
            btnFoto.Size = new Size(100, 30);

            CrearBoton("💾 AÑADIR", 600, 20, Color.Cyan, p, (s, e) => {
                string sql = "INSERT INTO videojuegos (titulo, categoria, precio, fabricante, anio, visible, imagen, descripcion) VALUES (@t, @c, @p, @f, @a, @v, @i, @d)";
                EjecutarAccionJuego(sql);
            });
            CrearBoton("✏️ EDITAR", 600, 60, Color.Magenta, p, (s, e) => {
                if (idJuegoEditando == -1) { MessageBox.Show("Selecciona un juego de la tabla primero."); return; }
                string sql = "UPDATE videojuegos SET titulo=@t, categoria=@c, precio=@p, fabricante=@f, anio=@a, visible=@v, imagen=@i, descripcion=@d WHERE id_juego=" + idJuegoEditando;
                EjecutarAccionJuego(sql);
            });
            CrearBoton("🗑️ BORRAR", 600, 100, Color.Red, p, (s, e) => {
                if (idJuegoEditando != -1) { EjecutarQuerySegura("DELETE FROM videojuegos WHERE id_juego=" + idJuegoEditando, null, null); CargarGridJuegos(); CargarEscaparate("TODO"); LimpiarInputsJuego(); }
            });
            CrearBoton("🧹", 600, 140, Color.White, p, (s, e) => LimpiarInputsJuego()).Size = new Size(40, 35);

            tablaJuegos = CrearGrid(30, 180, 720, 280, p);
            tablaJuegos.CellClick += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    var row = tablaJuegos.Rows[e.RowIndex];
                    idJuegoEditando = Convert.ToInt32(row.Cells["id_juego"].Value);
                    txtJuegoTitulo.Text = row.Cells["titulo"].Value.ToString();
                    txtJuegoCat.Text = row.Cells["categoria"].Value.ToString();
                    txtJuegoPrecio.Text = row.Cells["precio"].Value.ToString();
                    txtJuegoFab.Text = row.Cells["fabricante"].Value.ToString();
                    txtJuegoAnio.Text = row.Cells["anio"].Value.ToString();
                    checkJuegoVisible.Checked = Convert.ToBoolean(row.Cells["visible"].Value);
                    txtJuegoDesc.Text = row.Cells["descripcion"].Value != null ? row.Cells["descripcion"].Value.ToString() : "";
                    if (row.Cells["imagen"].Value != DBNull.Value) using (var ms = new MemoryStream((byte[])row.Cells["imagen"].Value)) picJuegoAdmin.Image = Image.FromStream(ms);
                    else picJuegoAdmin.Image = null;
                }
            };
        }

        private void EjecutarAccionJuego(string sql)
        {
            try
            {
                byte[] img = null;
                if (picJuegoAdmin.Image != null) using (var ms = new MemoryStream()) { picJuegoAdmin.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); img = ms.ToArray(); }
                var p = new MySqlParameter[] {
                    new MySqlParameter("@t", txtJuegoTitulo.Text),
                    new MySqlParameter("@c", txtJuegoCat.Text),
                    new MySqlParameter("@p", decimal.Parse(txtJuegoPrecio.Text)),
                    new MySqlParameter("@f", txtJuegoFab.Text),
                    new MySqlParameter("@a", int.Parse(txtJuegoAnio.Text)),
                    new MySqlParameter("@v", checkJuegoVisible.Checked ? 1 : 0),
                    new MySqlParameter("@i", img),
                    new MySqlParameter("@d", txtJuegoDesc.Text)
                };
                EjecutarQuerySegura(sql, p, null); CargarGridJuegos(); CargarEscaparate("TODO"); LimpiarInputsJuego();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // --- HELPERS BÁSICOS ---
        private void CargarGridJuegos() { EjecutarQuerySegura("SELECT * FROM videojuegos", null, (dt) => tablaJuegos.DataSource = dt); }
        private void CargarUsuarios() { EjecutarQuerySegura("SELECT NombreUsuario, email, rol, estado FROM usuarios", null, (dt) => tablaUsuarios.DataSource = dt); }
        private void EjecutarQuerySegura(string sql, MySqlParameter[] p, Action<DataTable> ok)
        {
            DatabaseConnection db = new DatabaseConnection();
            using (var conn = db.GetConnection()) { conn.Open(); var cmd = new MySqlCommand(sql, conn); if (p != null) cmd.Parameters.AddRange(p); if (ok != null) { var da = new MySqlDataAdapter(cmd); DataTable dt = new DataTable(); da.Fill(dt); ok(dt); } else cmd.ExecuteNonQuery(); }
        }
        private void LimpiarUser() { txtNuevoUser.Clear(); txtNuevoPass.Clear(); txtEmail.Clear(); }
        private void LimpiarInputsJuego() { idJuegoEditando = -1; txtJuegoTitulo.Clear(); txtJuegoPrecio.Clear(); txtJuegoDesc.Clear(); picJuegoAdmin.Image = null; }
        private void MostrarAdmin() { panelContenedorAdmin.Visible = true; flowCatalogo.Visible = false; panelContenedorAdmin.BringToFront(); }
        private void MostrarHome() { panelContenedorAdmin.Visible = false; flowCatalogo.Visible = true; }
        private TextBox CrearInput(int x, int y, int w, string p, Panel pan) { TextBox t = new TextBox() { Location = new Point(x, y), Width = w, PlaceholderText = p, BackColor = Color.FromArgb(30, 30, 50), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle }; pan.Controls.Add(t); return t; }
        private Button CrearBoton(string t, int x, int y, Color c, Panel pan, EventHandler evt) { Button b = new Button() { Text = t, Location = new Point(x, y), Size = new Size(100, 35), ForeColor = c, FlatStyle = FlatStyle.Flat }; b.FlatAppearance.BorderColor = c; b.Click += evt; pan.Controls.Add(b); return b; }
        private DataGridView CrearGrid(int x, int y, int w, int h, Panel p) { DataGridView g = new DataGridView() { Location = new Point(x, y), Size = new Size(w, h), BackgroundColor = Color.FromArgb(15, 15, 30), BorderStyle = BorderStyle.None, AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill }; g.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 50); g.DefaultCellStyle.ForeColor = Color.White; p.Controls.Add(g); return g; }
        private void ConfigurarEventosExtra() { if (this.btnSalir != null) this.btnSalir.Click += (s, e) => Application.Exit(); if (this.btnCerrarSesion != null) this.btnCerrarSesion.Click += (s, e) => { esCierreDeSesion = true; this.Close(); }; this.FormClosing += (s, e) => { if (esCierreDeSesion) new Form1().Show(); else Application.Exit(); }; }
    }
}