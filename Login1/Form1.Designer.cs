namespace Login1
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelLinea = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            // 
            // COLORES
            // 
            System.Drawing.Color colorFondo = System.Drawing.Color.FromArgb(15, 15, 30);
            System.Drawing.Color colorCaja = System.Drawing.Color.FromArgb(30, 30, 50);
            System.Drawing.Color neonCian = System.Drawing.Color.Cyan;
            System.Drawing.Color neonRosa = System.Drawing.Color.Magenta;
            System.Drawing.Color textoBlanco = System.Drawing.Color.WhiteSmoke;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = neonRosa;
            this.lblTitulo.Location = new System.Drawing.Point(60, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "FIPPY GAMES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // panelLinea
            // 
            this.panelLinea.BackColor = neonCian;
            this.panelLinea.Location = new System.Drawing.Point(70, 90);
            this.panelLinea.Name = "panelLinea";
            this.panelLinea.Size = new System.Drawing.Size(260, 3);
            this.panelLinea.TabIndex = 8;

            // 
            // label1 (Usuario)
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = neonCian;
            this.label1.Location = new System.Drawing.Point(50, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "USUARIO";

            // 
            // textBox1
            // 
            this.textBox1.BackColor = colorCaja;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.ForeColor = textoBlanco;
            this.textBox1.Location = new System.Drawing.Point(50, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 29);
            this.textBox1.TabIndex = 1;

            // 
            // label2 (Contraseña)
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = neonCian;
            this.label2.Location = new System.Drawing.Point(50, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "CONTRASEÑA";

            // 
            // textBox2
            // 
            this.textBox2.BackColor = colorCaja;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox2.ForeColor = textoBlanco;
            this.textBox2.Location = new System.Drawing.Point(50, 225);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.Size = new System.Drawing.Size(300, 29);
            this.textBox2.TabIndex = 2;

            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = neonCian;
            this.btnLogin.FlatAppearance.BorderSize = 2;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 50, 50);
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 20, 40);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = neonCian;
            this.btnLogin.Location = new System.Drawing.Point(50, 290);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(140, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "ENTRAR";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistro.FlatAppearance.BorderColor = neonRosa;
            this.btnRegistro.FlatAppearance.BorderSize = 2;
            this.btnRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(50, 0, 50);
            this.btnRegistro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 0, 20);
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistro.ForeColor = neonRosa;
            this.btnRegistro.Location = new System.Drawing.Point(210, 290);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(140, 45);
            this.btnRegistro.TabIndex = 4;
            this.btnRegistro.Text = "REGISTRAR";
            this.btnRegistro.UseVisualStyleBackColor = false;
            // AQUI ESTABA EL ERROR: Ahora apunta correctamente al metodo btnRegistro_Click
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);

            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.Gray;
            this.btnSalir.Location = new System.Drawing.Point(365, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 30);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // Añade esto justo después de la configuración de this.btnSalir
this.btnMinimizar = new System.Windows.Forms.Button();
this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
this.btnMinimizar.FlatAppearance.BorderSize = 0;
this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(30, 30, 50);
this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
this.btnMinimizar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
this.btnMinimizar.ForeColor = System.Drawing.Color.Gray;
this.btnMinimizar.Location = new System.Drawing.Point(330, 5); // Un poco a la izquierda de la X
this.btnMinimizar.Name = "btnMinimizar";
this.btnMinimizar.Size = new System.Drawing.Size(30, 30);
this.btnMinimizar.TabIndex = 9;
this.btnMinimizar.Text = "—";
this.btnMinimizar.UseVisualStyleBackColor = false;
this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);

// Y no olvides añadirlo a los controles del formulario al final:
this.Controls.Add(this.btnMinimizar);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = colorFondo;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.panelLinea);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "Form1";
            this.Text = "Fippy Games Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelLinea;
    }
}