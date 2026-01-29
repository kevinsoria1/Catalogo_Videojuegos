namespace Login1
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnMisJuegos = new System.Windows.Forms.Button();
            this.btnDestacados = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnSoporte = new System.Windows.Forms.Button();
            this.btnTienda = new System.Windows.Forms.Button();
            this.btnComunidad = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.flowPanelJuegos = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLateral.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();

            // COLORES NEON
            System.Drawing.Color colorFondo = System.Drawing.Color.FromArgb(15, 15, 30);
            System.Drawing.Color colorPanel = System.Drawing.Color.FromArgb(25, 20, 45);
            System.Drawing.Color colorNeonAzul = System.Drawing.Color.Cyan;
            System.Drawing.Color colorNeonRosa = System.Drawing.Color.Magenta;
            System.Drawing.Color colorBotonFondo = System.Drawing.Color.FromArgb(40, 35, 60);

            // panelLateral
            this.panelLateral.BackColor = colorPanel;
            this.panelLateral.Controls.Add(this.btnConfiguracion);
            this.panelLateral.Controls.Add(this.btnMisJuegos);
            this.panelLateral.Controls.Add(this.btnDestacados);
            this.panelLateral.Controls.Add(this.panelLogo);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(220, 600);
            this.panelLateral.TabIndex = 0;

            // panelLogo
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 100);
            this.panelLogo.TabIndex = 3;

            // lblLogo
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = colorNeonAzul;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(220, 100);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "GAMES";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnDestacados
            this.btnDestacados.BackColor = colorBotonFondo;
            this.btnDestacados.FlatAppearance.BorderColor = colorNeonRosa;
            this.btnDestacados.FlatAppearance.BorderSize = 1;
            this.btnDestacados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(70, 0, 70);
            this.btnDestacados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestacados.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDestacados.ForeColor = System.Drawing.Color.White;
            this.btnDestacados.Location = new System.Drawing.Point(20, 120);
            this.btnDestacados.Name = "btnDestacados";
            this.btnDestacados.Size = new System.Drawing.Size(180, 45);
            this.btnDestacados.TabIndex = 0;
            this.btnDestacados.Text = "★ DESTACADOS";
            this.btnDestacados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDestacados.UseVisualStyleBackColor = false;

            // btnMisJuegos
            this.btnMisJuegos.BackColor = colorBotonFondo;
            this.btnMisJuegos.FlatAppearance.BorderColor = colorNeonAzul;
            this.btnMisJuegos.FlatAppearance.BorderSize = 1;
            this.btnMisJuegos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 60, 60);
            this.btnMisJuegos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMisJuegos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMisJuegos.ForeColor = System.Drawing.Color.White;
            this.btnMisJuegos.Location = new System.Drawing.Point(20, 180);
            this.btnMisJuegos.Name = "btnMisJuegos";
            this.btnMisJuegos.Size = new System.Drawing.Size(180, 45);
            this.btnMisJuegos.TabIndex = 1;
            this.btnMisJuegos.Text = "🎮 MIS JUEGOS";
            this.btnMisJuegos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMisJuegos.UseVisualStyleBackColor = false;

            // btnConfiguracion
            this.btnConfiguracion.BackColor = colorBotonFondo;
            this.btnConfiguracion.FlatAppearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.btnConfiguracion.FlatAppearance.BorderSize = 1;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfiguracion.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracion.Location = new System.Drawing.Point(20, 240);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(180, 45);
            this.btnConfiguracion.TabIndex = 2;
            this.btnConfiguracion.Text = "⚙ AJUSTES";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.UseVisualStyleBackColor = false;

            // panelSuperior
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(20, 20, 40);
            this.panelSuperior.Controls.Add(this.btnMinimizar);
            this.panelSuperior.Controls.Add(this.btnUsuario);
            this.panelSuperior.Controls.Add(this.btnCerrarSesion);
            this.panelSuperior.Controls.Add(this.btnSoporte);
            this.panelSuperior.Controls.Add(this.btnTienda);
            this.panelSuperior.Controls.Add(this.btnComunidad);
            this.panelSuperior.Controls.Add(this.btnSalir);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(220, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(780, 80);
            this.panelSuperior.TabIndex = 1;

            // btnMinimizar
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimizar.ForeColor = System.Drawing.Color.Gray;
            this.btnMinimizar.Location = new System.Drawing.Point(695, 5);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(35, 35);
            this.btnMinimizar.TabIndex = 7;
            this.btnMinimizar.Text = "—";
            this.btnMinimizar.UseVisualStyleBackColor = false;

            // btnComunidad
            this.btnComunidad.BackColor = System.Drawing.Color.Transparent;
            this.btnComunidad.FlatAppearance.BorderSize = 0;
            this.btnComunidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.btnComunidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComunidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnComunidad.ForeColor = colorNeonAzul;
            this.btnComunidad.Location = new System.Drawing.Point(20, 25);
            this.btnComunidad.Name = "btnComunidad";
            this.btnComunidad.Size = new System.Drawing.Size(110, 35);
            this.btnComunidad.TabIndex = 0;
            this.btnComunidad.Text = "COMUNIDAD";
            this.btnComunidad.UseVisualStyleBackColor = false;

            // btnTienda
            this.btnTienda.BackColor = System.Drawing.Color.Transparent;
            this.btnTienda.FlatAppearance.BorderSize = 0;
            this.btnTienda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.btnTienda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTienda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTienda.ForeColor = colorNeonRosa;
            this.btnTienda.Location = new System.Drawing.Point(140, 25);
            this.btnTienda.Name = "btnTienda";
            this.btnTienda.Size = new System.Drawing.Size(100, 35);
            this.btnTienda.TabIndex = 1;
            this.btnTienda.Text = "TIENDA";
            this.btnTienda.UseVisualStyleBackColor = false;

            // btnSoporte
            this.btnSoporte.BackColor = System.Drawing.Color.Transparent;
            this.btnSoporte.FlatAppearance.BorderSize = 0;
            this.btnSoporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 30, 60);
            this.btnSoporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoporte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSoporte.ForeColor = System.Drawing.Color.LightGray;
            this.btnSoporte.Location = new System.Drawing.Point(250, 25);
            this.btnSoporte.Name = "btnSoporte";
            this.btnSoporte.Size = new System.Drawing.Size(100, 35);
            this.btnSoporte.TabIndex = 2;
            this.btnSoporte.Text = "SOPORTE";
            this.btnSoporte.UseVisualStyleBackColor = false;

            // btnUsuario
            this.btnUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnUsuario.FlatAppearance.BorderColor = colorNeonAzul;
            this.btnUsuario.FlatAppearance.BorderSize = 1;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUsuario.ForeColor = colorNeonAzul;
            this.btnUsuario.Location = new System.Drawing.Point(400, 22);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(130, 40);
            this.btnUsuario.TabIndex = 5;
            this.btnUsuario.Text = "USUARIO";
            this.btnUsuario.UseVisualStyleBackColor = false;

            // btnCerrarSesion
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 1;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 0, 0);
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.IndianRed;
            this.btnCerrarSesion.Location = new System.Drawing.Point(540, 22);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 40);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "CERRAR SESIÓN";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;

            // btnSalir
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.Gray;
            this.btnSalir.Location = new System.Drawing.Point(735, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(35, 35);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;

            // flowPanelJuegos (IMPORTANTE: Ahora está vacío y oculto para no estorbar)
            this.flowPanelJuegos.AutoScroll = true;
            this.flowPanelJuegos.BackColor = colorFondo;
            this.flowPanelJuegos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelJuegos.Location = new System.Drawing.Point(220, 80);
            this.flowPanelJuegos.Name = "flowPanelJuegos";
            this.flowPanelJuegos.Padding = new System.Windows.Forms.Padding(30);
            this.flowPanelJuegos.Size = new System.Drawing.Size(780, 520);
            this.flowPanelJuegos.TabIndex = 2;
            this.flowPanelJuegos.Visible = false; // LO OCULTAMOS PARA QUE SE VEA EL NUEVO

            // Form2
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = colorFondo;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.flowPanelJuegos);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelLateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cyber Launcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.panelLateral.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelSuperior.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panelSuperior;
        public System.Windows.Forms.FlowLayoutPanel flowPanelJuegos; // Se mantiene por compatibilidad pero se oculta
        private System.Windows.Forms.Button btnDestacados;
        private System.Windows.Forms.Button btnMisJuegos;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnComunidad;
        private System.Windows.Forms.Button btnTienda;
        private System.Windows.Forms.Button btnSoporte;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}