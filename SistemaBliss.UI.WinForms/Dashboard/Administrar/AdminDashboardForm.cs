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


        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            navegacionUI.AbrirFormEnPanel(typeof(AdminClienteForm), "Estadistica Completa");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            navegacionUI.AbrirFormEnPanel(typeof(AdminEmpleadoForm), "Estadistica Completa");

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            navegacionUI.AbrirFormEnPanel(typeof(AdminEmpresaForm), "Estadistica Completa");

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AdminLoginForm login = new AdminLoginForm();
            login.Show();
            this.Visible = false;
        }
    }
}
