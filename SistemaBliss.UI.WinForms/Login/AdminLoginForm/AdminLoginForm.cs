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
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario del panel de control
            AdminDashboardForm adminDashboardForm = new AdminDashboardForm();
            adminDashboardForm.Show();

            // Cerrar la ventana de inicio de sesión
            this.Close();
        }
    }
}
