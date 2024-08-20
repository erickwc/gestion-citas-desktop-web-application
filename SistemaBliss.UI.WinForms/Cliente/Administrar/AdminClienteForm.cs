using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaBliss.BL;
using SistemaBliss.EN;

namespace SistemaBliss.UI.WinForms
{
    public partial class AdminClienteForm : Form
    {
        // Conexion a la tabla de Clientes en la DB
        UsuarioBL usuarioBL = new UsuarioBL();
        //Variables
        List<Usuario> Lista = new List<Usuario>();

        public AdminClienteForm()
        {
            InitializeComponent();
        }

        NavegacionUI navegacionUI = new NavegacionUI();

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            navegacionUI.AbrirFormEnPanel(typeof(AgregarClienteForm), "Estadistica Completa");
        }

        public void CargarUsuarios()
        {
            // Conexion a la tabla de cliente en la BD

            UsuarioBL usuarioBL = new UsuarioBL();

            // Inicializar lista 
            List<object> usuarios = new List<object>();
            usuarios.Add(new { Value = 0, Text = "SELECCIONAR" });
            usuarios.Add(new { Value = 1, Text = "Nombre" });
            usuarios.Add(new { Value = 2, Text = "Apellido" });
            usuarios.Add(new { Value = 3, Text = "Telefono" });
            // Opcion por defecto

            // Obtener lista de Cargos de la DB
            //usuarios.AddRange(usuarioBL.Buscar(new Usuario()));
            FiltroClienteComboBox.DataSource = usuarios;


            // Configurar texto y valor de la lista de seleccion
            FiltroClienteComboBox.DisplayMember = "Text";
            FiltroClienteComboBox.ValueMember = "Value";
            // FiltroClienteComboBox.ValueMember = "IdCliente";
        }
        private void AdminClienteForm_Load(object sender, EventArgs e)
        {
            //Cargar ComboBoxs en el formulario
            CargarUsuarios();

        }
        private void CargarLista()
        {
            listaClientesDataGridView.DataSource = ""; // Vaciar DataGridView
            listaClientesDataGridView.DataSource = Lista; // Agregar objetos de lista
            listaClientesDataGridView.Columns["IdMunicipio"].Visible = false;
            listaClientesDataGridView.Columns["IdDepartamento"].Visible = false;
            listaClientesDataGridView.Columns["IdRol"].Visible = false;
            listaClientesDataGridView.Columns["IdEstado"].Visible = false;
            listaClientesDataGridView.Columns["Municipio"].Visible = false;
            listaClientesDataGridView.Columns["Rol"].Visible = false;
            listaClientesDataGridView.Columns["Estado"].Visible = false;
            listaClientesDataGridView.Columns["Departamento"].Visible = false;
            listaClientesDataGridView.Columns["IdEstado"].Visible = false;
            listaClientesDataGridView.Columns["Contrasena"].Visible = false;
            listaClientesDataGridView.Columns["Direccion"].Visible = false;
            listaClientesDataGridView.Columns["UrlImagen"].Visible = false;
            listaClientesDataGridView.Columns["CorreoElectronico"].Visible = false;
        }
        private void BarraDeBusquedaClienteTextBox_TextChanged(object sender, EventArgs e)
        {
            // Obtener los filtros de busquedas
            Usuario usuario = new Usuario();
            switch (FiltroClienteComboBox.SelectedValue)
            {
                case 1: // Nombre
                    usuario.Nombre = BarraDeBusquedaClienteTextBox.Text;
                    break;
                case 2: // Apellido
                    usuario.Apellido = BarraDeBusquedaClienteTextBox.Text;
                    break;
                case 3: // Telefono
                    usuario.Telefono = BarraDeBusquedaClienteTextBox.Text;
                    break;
                default:
                    // Si no se selecciona ningún filtro válido, puedes retornar o manejar el caso
                    return;
            }


            // Ejecutar busqueda
            Lista = usuarioBL.Buscar(usuario);
            CargarLista();
        }
    }
}
