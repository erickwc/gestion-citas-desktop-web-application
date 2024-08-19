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
    public partial class AdminEmpleadoForm : Form
    {
        public AdminEmpleadoForm()
        {
            InitializeComponent();
        }

        NavegacionUI navegacionUI = new NavegacionUI();


        private void btn_profesiones_Click(object sender, EventArgs e)
        {
            AdminProfesionForm profesion = new AdminProfesionForm();
            profesion.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            navegacionUI.AbrirFormEnPanel(typeof(AgregarEmpleadoForm), "Estadistica Completa");
        }
    }
}
