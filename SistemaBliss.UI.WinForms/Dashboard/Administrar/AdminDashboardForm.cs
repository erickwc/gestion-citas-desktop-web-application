using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBliss.UI.WinForms
{
    public partial class AdminDashboardForm : Form
    {

        public AdminDashboardForm()
        {
            InitializeComponent();

        }

        NavegacionUI navegacionUI = new NavegacionUI();

        private void AbrirFormEnPanel(object Form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form fh = Form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(fh);
            this.mainPanel.Tag = fh;
            fh.Show();

        }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AdminClienteForm());
            nombreSeccionLabel.Text = "Clientes";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AdminClienteForm());
            nombreSeccionLabel.Text = "Clientes";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AdminEmpleadoForm());
            nombreSeccionLabel.Text = "Empleados";

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AdminEmpresaForm());
            nombreSeccionLabel.Text = "Empresa";

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AdminLoginForm login = new AdminLoginForm();
            login.Show();
            this.Visible = false;

        }

        private void AdminDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            
        }

        private void nombreSeccionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
