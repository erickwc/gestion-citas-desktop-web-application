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
//referencias 
using ToolsForms;

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
        private void modificarEmpButton_Click(object sender, EventArgs e)
        {
            // Obtener la llave primaria (PK) del registro seleccionado
            short idTabla = (short)ToolsForm.ObtenerIdGrid(TablaEmpleadoDataGridView);
            if (idTabla > 0)
            {
                // Abrir formulario para modificar el empleado seleccionado
                AgregarEmpleadoForm formModificar = new AgregarEmpleadoForm();
               //ESTA TAMBIEN DA ERROR formModificar.idUsuario = idTabla;
                formModificar.ShowDialog();

                // Actualizar lista simulando click en el botón de BUSCAR
               // ESTA DA ERROR guardarButton_Click.PerformClick();
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar el registro que desea editar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
    }


}
    

