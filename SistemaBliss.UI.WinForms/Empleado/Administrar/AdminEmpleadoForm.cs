using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//REFERENCIAS DEL PROYECTO
using SistemaBliss.EN;
using SistemaBliss.BL;

namespace SistemaBliss.UI.WinForms
{
    public partial class AdminEmpleadoForm : Form
    {   
        UsuarioBL usuarioBL = new UsuarioBL();
        
        List<Usuario> lista = new List<Usuario>();
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
            // Abrir formulario para registrar un nuevo cliente 
            AgregarEmpleadoForm frmResigistro = new AgregarEmpleadoForm();
            frmResigistro.ShowDialog();
        }

        private void AdminEmpleadoForm_Load(object sender, EventArgs e)
        {

        }

        private void AgregarEmpleadoButton_Click(object sender, EventArgs e)
        {
            AgregarEmpleadoForm agregarEmpleado = new AgregarEmpleadoForm();
            agregarEmpleado.ShowDialog();
        }
    }
}
