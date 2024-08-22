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

        public void CargarFiltros()
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

        private void OcultarColumnas(DataGridView datagrid)
        {
            datagrid.Columns["IdMunicipio"].Visible = false;
            datagrid.Columns["IdDepartamento"].Visible = false;
            //datagrid.Columns["IdRol"].Visible = false;
            datagrid.Columns["IdUsuario"].Visible = false;
            datagrid.Columns["Contrasena"].Visible = false;
            datagrid.Columns["Direccion"].Visible = false;
            datagrid.Columns["UrlImagen"].Visible = false;
            datagrid.Columns["CorreoElectronico"].Visible = false;
            datagrid.Columns["Dui"].Visible = false;
        }

        private void CargarLista()
        {
            var selectedTab = tabControlGuna.SelectedTab;

            if (selectedTab.Text == "Activos")
            {
                listaClientesDataGridView.DataSource = "";
                usuarioBL.CargarEstadoVirtual(Lista);
                usuarioBL.CargarRolVirtual(Lista);
                listaClientesDataGridView.DataSource = Lista.Select(x => new UsuarioVM(x)).ToList();
                OcultarColumnas(listaClientesDataGridView);
            }
            if (selectedTab.Text == "Inactivos")
            {
                listaClientesInactivosDataGridView.DataSource = "";
                usuarioBL.CargarEstadoVirtual(Lista);
                usuarioBL.CargarRolVirtual(Lista);
                listaClientesInactivosDataGridView.DataSource = Lista.Select(x => new UsuarioVM(x)).ToList();
                OcultarColumnas(listaClientesInactivosDataGridView);
            }
        }

        private void CargarTarjetas()
        {
            UsuarioBL usuarioBL = new UsuarioBL();

            Usuario totalClientes = usuarioBL.ContarTotalClientes();
            Usuario clientesActivos = usuarioBL.ContarClientesActivos();
            Usuario clientesInactivos = usuarioBL.ContarClientesInactivos();

            // Asignación de los valores a las etiquetas
            ClientesTotalesLabel.Text = totalClientes.ClientesTotales.ToString();
            ClientesActivosLabel.Text = clientesActivos.ClientesActivos.ToString();
            ClientesInactivosLabel.Text = clientesInactivos.ClientesInactivos.ToString();
        }

        
        private void AdminClienteForm_Load(object sender, EventArgs e)
        {

            CargarTarjetas();


            //Cargar ComboBoxs en el formulario
            CargarFiltros();

        }
       
        private void BarraDeBusquedaClienteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BarraDeBusquedaClienteTextBox.Text))
            {
                // Limpiar las tablas
                listaClientesDataGridView.DataSource = null;
                listaClientesInactivosDataGridView.DataSource = null;
                return;
            }

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

            var selectedTab = tabControlGuna.SelectedTab;

            if (selectedTab.Text == "Activos")
            {
                Lista = usuarioBL.BuscarClientesActivos(usuario);
                CargarLista();
                CargarTarjetas();

            }
            if (selectedTab.Text == "Inactivos")
            {

                Lista = usuarioBL.BuscarClientesInctivos(usuario);
                CargarLista();
                CargarTarjetas();

            }
        }

        private void FiltroClienteComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BarraDeBusquedaClienteTextBox.Text = "";
        }

        

        private void modificarClienteButton_Click(object sender, EventArgs e)
        {
            var selectedTab = tabControlGuna.SelectedTab;

            if (selectedTab.Text == "Activos")
            {
                short idTabla = (short)ToolsForm.ObtenerIdGrid(listaClientesDataGridView);
                if (idTabla > 0)
                {
                    // Abrir formulario para modificar el empleado seleccionado
                    AgregarClienteForm formModificar = new AgregarClienteForm();
                    formModificar.idUsuario = idTabla;
                    formModificar.ShowDialog();

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

                    Lista = usuarioBL.BuscarClientesActivos(usuario);
                    CargarLista();
                    CargarTarjetas();
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar el registro que desea editar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (selectedTab.Text == "Inactivos")
            {

                short idTabla = (short)ToolsForm.ObtenerIdGrid(listaClientesInactivosDataGridView);
                if (idTabla > 0)
                {
                    // Abrir formulario para modificar el empleado seleccionado
                    AgregarEmpleadoForm formModificar = new AgregarEmpleadoForm();
                    formModificar.idUsuario = idTabla;
                    formModificar.ShowDialog();

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

                    Lista = usuarioBL.BuscarClientesInctivos(usuario);
                    CargarLista();
                    CargarTarjetas();
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar el registro que desea editar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void AgregarClienteButton_Click(object sender, EventArgs e)
        {
            AgregarClienteForm agregarEmpleado = new AgregarClienteForm();
            agregarEmpleado.ShowDialog();

            CargarTarjetas();
        }
    }
}
