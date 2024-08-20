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

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AdminClienteForm());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AdminEmpleadoForm());

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AdminEmpresaForm());

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AdminLoginForm login = new AdminLoginForm();
            login.Show();
            this.Visible = false;
        }
    }
}
