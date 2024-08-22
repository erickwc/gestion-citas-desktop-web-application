namespace SistemaBliss.UI.WinForms
{
    partial class AdminLoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.telefonoTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contraseñaTexBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.iniciarSesionButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.telefonoTextBox.Animated = true;
            this.telefonoTextBox.BorderRadius = 10;
            this.telefonoTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.telefonoTextBox.DefaultText = "";
            this.telefonoTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.telefonoTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.telefonoTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.telefonoTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.telefonoTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(79)))), ((int)(((byte)(217)))));
            this.telefonoTextBox.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(79)))), ((int)(((byte)(217)))));
            this.telefonoTextBox.Location = new System.Drawing.Point(482, 289);
            this.telefonoTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.PasswordChar = '\0';
            this.telefonoTextBox.PlaceholderText = "Ingrese su numero de telefono";
            this.telefonoTextBox.SelectedText = "";
            this.telefonoTextBox.Size = new System.Drawing.Size(409, 43);
            this.telefonoTextBox.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(49)))));
            this.label4.Location = new System.Drawing.Point(507, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Telefono";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // contraseñaTexBox
            // 
            this.contraseñaTexBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.contraseñaTexBox.Animated = true;
            this.contraseñaTexBox.BorderRadius = 10;
            this.contraseñaTexBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.contraseñaTexBox.DefaultText = "";
            this.contraseñaTexBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.contraseñaTexBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.contraseñaTexBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.contraseñaTexBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.contraseñaTexBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(79)))), ((int)(((byte)(217)))));
            this.contraseñaTexBox.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contraseñaTexBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(79)))), ((int)(((byte)(217)))));
            this.contraseñaTexBox.Location = new System.Drawing.Point(482, 399);
            this.contraseñaTexBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.contraseñaTexBox.Name = "contraseñaTexBox";
            this.contraseñaTexBox.PasswordChar = '\0';
            this.contraseñaTexBox.PlaceholderText = "Ingrese su contraseña";
            this.contraseñaTexBox.SelectedText = "";
            this.contraseñaTexBox.Size = new System.Drawing.Size(409, 43);
            this.contraseñaTexBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(49)))));
            this.label1.Location = new System.Drawing.Point(507, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Contraseña";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(49)))));
            this.label2.Location = new System.Drawing.Point(482, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hola, Bienvenido de nuevo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(482, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(409, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ingresa los siguientes datos para iniciar sesion";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::SistemaBliss.UI.WinForms.Properties.Resources.icon_telefono;
            this.pictureBox1.Location = new System.Drawing.Point(482, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::SistemaBliss.UI.WinForms.Properties.Resources.icon_contraseña;
            this.pictureBox2.Location = new System.Drawing.Point(482, 370);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // iniciarSesionButton
            // 
            this.iniciarSesionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iniciarSesionButton.Animated = true;
            this.iniciarSesionButton.BorderRadius = 10;
            this.iniciarSesionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iniciarSesionButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.iniciarSesionButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.iniciarSesionButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.iniciarSesionButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.iniciarSesionButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(79)))), ((int)(((byte)(217)))));
            this.iniciarSesionButton.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.iniciarSesionButton.ForeColor = System.Drawing.Color.White;
            this.iniciarSesionButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(69)))), ((int)(((byte)(206)))));
            this.iniciarSesionButton.Location = new System.Drawing.Point(482, 496);
            this.iniciarSesionButton.Name = "iniciarSesionButton";
            this.iniciarSesionButton.Size = new System.Drawing.Size(409, 46);
            this.iniciarSesionButton.TabIndex = 25;
            this.iniciarSesionButton.Text = "Iniciar Sesión";
            this.iniciarSesionButton.Click += new System.EventHandler(this.iniciarSesionButton_Click);
            // 
            // AdminLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 709);
            this.Controls.Add(this.iniciarSesionButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contraseñaTexBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.telefonoTextBox);
            this.Controls.Add(this.label4);
            this.Name = "AdminLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox telefonoTextBox;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox contraseñaTexBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button iniciarSesionButton;
    }
}