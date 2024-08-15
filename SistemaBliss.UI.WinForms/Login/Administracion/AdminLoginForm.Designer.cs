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
            this.SaludoLoginLabel = new System.Windows.Forms.Label();
            this.InstruccionLabel = new System.Windows.Forms.Label();
            this.TelefonoLoginLabel = new System.Windows.Forms.Label();
            this.TelefonoLoginTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ContrasenaTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ContrasenaLabel = new System.Windows.Forms.Label();
            this.IniciarSesionButton = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // SaludoLoginLabel
            // 
            this.SaludoLoginLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaludoLoginLabel.AutoSize = true;
            this.SaludoLoginLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaludoLoginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(49)))));
            this.SaludoLoginLabel.Location = new System.Drawing.Point(369, 70);
            this.SaludoLoginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SaludoLoginLabel.Name = "SaludoLoginLabel";
            this.SaludoLoginLabel.Size = new System.Drawing.Size(313, 30);
            this.SaludoLoginLabel.TabIndex = 0;
            this.SaludoLoginLabel.Text = "Hola, Bienvenido de nuevo";
            // 
            // InstruccionLabel
            // 
            this.InstruccionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InstruccionLabel.AutoSize = true;
            this.InstruccionLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstruccionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.InstruccionLabel.Location = new System.Drawing.Point(318, 110);
            this.InstruccionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InstruccionLabel.Name = "InstruccionLabel";
            this.InstruccionLabel.Size = new System.Drawing.Size(440, 25);
            this.InstruccionLabel.TabIndex = 1;
            this.InstruccionLabel.Text = "Ingresa los siguientes datos para iniciar sesión";
            // 
            // TelefonoLoginLabel
            // 
            this.TelefonoLoginLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TelefonoLoginLabel.AutoSize = true;
            this.TelefonoLoginLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelefonoLoginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(49)))));
            this.TelefonoLoginLabel.Location = new System.Drawing.Point(349, 175);
            this.TelefonoLoginLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TelefonoLoginLabel.Name = "TelefonoLoginLabel";
            this.TelefonoLoginLabel.Size = new System.Drawing.Size(77, 21);
            this.TelefonoLoginLabel.TabIndex = 3;
            this.TelefonoLoginLabel.Text = "Telefono";
            // 
            // TelefonoLoginTextBox
            // 
            this.TelefonoLoginTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TelefonoLoginTextBox.BorderRadius = 8;
            this.TelefonoLoginTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TelefonoLoginTextBox.DefaultText = "";
            this.TelefonoLoginTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TelefonoLoginTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TelefonoLoginTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TelefonoLoginTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TelefonoLoginTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TelefonoLoginTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelefonoLoginTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TelefonoLoginTextBox.Location = new System.Drawing.Point(354, 204);
            this.TelefonoLoginTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TelefonoLoginTextBox.Name = "TelefonoLoginTextBox";
            this.TelefonoLoginTextBox.PasswordChar = '\0';
            this.TelefonoLoginTextBox.PlaceholderText = "Ingrese su numero de telefono";
            this.TelefonoLoginTextBox.SelectedText = "";
            this.TelefonoLoginTextBox.Size = new System.Drawing.Size(330, 40);
            this.TelefonoLoginTextBox.TabIndex = 6;
            // 
            // ContrasenaTextBox
            // 
            this.ContrasenaTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ContrasenaTextBox.BorderRadius = 8;
            this.ContrasenaTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ContrasenaTextBox.DefaultText = "";
            this.ContrasenaTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ContrasenaTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ContrasenaTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ContrasenaTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ContrasenaTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ContrasenaTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrasenaTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ContrasenaTextBox.Location = new System.Drawing.Point(354, 309);
            this.ContrasenaTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ContrasenaTextBox.Name = "ContrasenaTextBox";
            this.ContrasenaTextBox.PasswordChar = '\0';
            this.ContrasenaTextBox.PlaceholderText = "Ingresa su contraseña";
            this.ContrasenaTextBox.SelectedText = "";
            this.ContrasenaTextBox.Size = new System.Drawing.Size(330, 40);
            this.ContrasenaTextBox.TabIndex = 8;
            // 
            // ContrasenaLabel
            // 
            this.ContrasenaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ContrasenaLabel.AutoSize = true;
            this.ContrasenaLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrasenaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(49)))));
            this.ContrasenaLabel.Location = new System.Drawing.Point(349, 280);
            this.ContrasenaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ContrasenaLabel.Name = "ContrasenaLabel";
            this.ContrasenaLabel.Size = new System.Drawing.Size(97, 21);
            this.ContrasenaLabel.TabIndex = 7;
            this.ContrasenaLabel.Text = "Contraseña";
            // 
            // IniciarSesionButton
            // 
            this.IniciarSesionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IniciarSesionButton.BorderRadius = 8;
            this.IniciarSesionButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.IniciarSesionButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.IniciarSesionButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.IniciarSesionButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.IniciarSesionButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(79)))), ((int)(((byte)(217)))));
            this.IniciarSesionButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniciarSesionButton.ForeColor = System.Drawing.Color.White;
            this.IniciarSesionButton.Location = new System.Drawing.Point(353, 395);
            this.IniciarSesionButton.Name = "IniciarSesionButton";
            this.IniciarSesionButton.Size = new System.Drawing.Size(330, 40);
            this.IniciarSesionButton.TabIndex = 9;
            this.IniciarSesionButton.Text = "Iniciar Sesión";
            // 
            // AdminLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1011, 570);
            this.Controls.Add(this.IniciarSesionButton);
            this.Controls.Add(this.ContrasenaTextBox);
            this.Controls.Add(this.ContrasenaLabel);
            this.Controls.Add(this.TelefonoLoginTextBox);
            this.Controls.Add(this.TelefonoLoginLabel);
            this.Controls.Add(this.InstruccionLabel);
            this.Controls.Add(this.SaludoLoginLabel);
            this.Name = "AdminLoginForm";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SaludoLoginLabel;
        private System.Windows.Forms.Label InstruccionLabel;
        private System.Windows.Forms.Label TelefonoLoginLabel;
        private Guna.UI2.WinForms.Guna2TextBox TelefonoLoginTextBox;
        private Guna.UI2.WinForms.Guna2TextBox ContrasenaTextBox;
        private System.Windows.Forms.Label ContrasenaLabel;
        private Guna.UI2.WinForms.Guna2Button IniciarSesionButton;
    }
}