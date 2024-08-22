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
        // Conexion a la tabla de Clientes en la DB
        UsuarioBL usuarioBL = new UsuarioBL();
        //Variables
        List<Usuario> Lista = new List<Usuario>();
        public AdminEmpleadoForm()
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
            FiltroEmpleadoComboBox.DataSource = usuarios;


            // Configurar texto y valor de la lista de seleccion
            FiltroEmpleadoComboBox.DisplayMember = "Text";
            FiltroEmpleadoComboBox.ValueMember = "Value";
            // FiltroClienteComboBox.ValueMember = "IdCliente";
        }

        private void OcultarColumnas(DataGridView datagrid)
        {
            datagrid.Columns["IdMunicipio"].Visible = false;
            datagrid.Columns["IdDepartamento"].Visible = false;
            //datagrid.Columns["IdRol"].Visible = false;
            //datagrid.Columns["IdUsuario"].Visible = false;
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
                listaEmpleadosDataGridView.DataSource = "";
                usuarioBL.CargarEstadoVirtual(Lista);
                usuarioBL.CargarRolVirtual(Lista);
                listaEmpleadosDataGridView.DataSource = Lista.Select(x => new UsuarioVM(x)).ToList();
                OcultarColumnas(listaEmpleadosDataGridView);
            }
            if (selectedTab.Text == "Inactivos")
            {
                listaEmpleadosInactivosDataGridView.DataSource = "";
                usuarioBL.CargarEstadoVirtual(Lista);
                usuarioBL.CargarRolVirtual(Lista);
                listaEmpleadosInactivosDataGridView.DataSource = Lista.Select(x => new UsuarioVM(x)).ToList();
                OcultarColumnas(listaEmpleadosInactivosDataGridView);
            }
        }

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

        private void CargarTarjetas()
        {
            UsuarioBL usuarioBL = new UsuarioBL();

            Usuario totalEmpleados = usuarioBL.ContarEmpleadosTotales();
            Usuario EmpleadosActivos = usuarioBL.ContarEmpleadosActivos();
            Usuario EmpleadosInactivos = usuarioBL.ContarEmpleadosInactivos();

            // Asignación de los valores a las etiquetas
            CantidadEmpTotalLabel.Text = totalEmpleados.EmpleadosTotales.ToString();
            CantidadEmpActivosLabel.Text = EmpleadosActivos.EmpleadosActivos.ToString();
            CantidadEmpInactivosLabel.Text = EmpleadosInactivos.EmpleadosInactivos.ToString();
        }

        private void AdminEmpleadoForm_Load(object sender, EventArgs e)
        {
            CargarTarjetas();
            CargarFiltros();
        }

        private void AgregarEmpleadoButton_Click(object sender, EventArgs e)
        {
            AgregarEmpleadoForm agregarEmpleado = new AgregarEmpleadoForm();
            agregarEmpleado.ShowDialog();
            CargarTarjetas();
        }
        private void modificarEmpButton_Click(object sender, EventArgs e)
        {
            var selectedTab = tabControlGuna.SelectedTab;

            if (selectedTab.Text == "Activos")
            {
                short idTabla = (short)ToolsForm.ObtenerIdGrid(listaEmpleadosDataGridView);
                if (idTabla > 0)
                {
                    // Abrir formulario para modificar el empleado seleccionado
                    AgregarEmpleadoForm formModificar = new AgregarEmpleadoForm();
                    formModificar.idUsuario = idTabla;
                    formModificar.ShowDialog();

                    Usuario usuario = new Usuario();
                    switch (FiltroEmpleadoComboBox.SelectedValue)
                    {
                        case 1: // Nombre
                            usuario.Nombre = BarraDeBusquedaEmpleadoTextBox.Text;
                            break;
                        case 2: // Apellido
                            usuario.Apellido = BarraDeBusquedaEmpleadoTextBox.Text;
                            break;
                        case 3: // Telefono
                            usuario.Telefono = BarraDeBusquedaEmpleadoTextBox.Text;
                            break;
                        default:
                            // Si no se selecciona ningún filtro válido, puedes retornar o manejar el caso
                            return;
                    }

                    Lista = usuarioBL.BuscarEmpleadosActivos(usuario);
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar el registro que desea editar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (selectedTab.Text == "Inactivos")
            {

                short idTabla = (short)ToolsForm.ObtenerIdGrid(listaEmpleadosInactivosDataGridView);
                if (idTabla > 0)
                {
                    // Abrir formulario para modificar el empleado seleccionado
                    AgregarEmpleadoForm formModificar = new AgregarEmpleadoForm();
                    formModificar.idUsuario = idTabla;
                    formModificar.ShowDialog();

                    Usuario usuario = new Usuario();
                    switch (FiltroEmpleadoComboBox.SelectedValue)
                    {
                        case 1: // Nombre
                            usuario.Nombre = BarraDeBusquedaEmpleadoTextBox.Text;
                            break;
                        case 2: // Apellido
                            usuario.Apellido = BarraDeBusquedaEmpleadoTextBox.Text;
                            break;
                        case 3: // Telefono
                            usuario.Telefono = BarraDeBusquedaEmpleadoTextBox.Text;
                            break;
                        default:
                            // Si no se selecciona ningún filtro válido, puedes retornar o manejar el caso
                            return;
                    }

                    Lista = usuarioBL.BuscarEmpleadosInactivos(usuario);
                    CargarLista();
                    CargarTarjetas();
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar el registro que desea editar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void listaEmpleadosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void BarraDeBusquedaEmpleadoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BarraDeBusquedaEmpleadoTextBox.Text))
            {
                // Limpiar las tablas
                listaEmpleadosDataGridView.DataSource = null;
                listaEmpleadosInactivosDataGridView.DataSource = null;
                return;
            }

            // Obtener los filtros de busquedas
            Usuario usuario = new Usuario();
            switch (FiltroEmpleadoComboBox.SelectedValue)
            {
                case 1: // Nombre
                    usuario.Nombre = BarraDeBusquedaEmpleadoTextBox.Text;
                    break;
                case 2: // Apellido
                    usuario.Apellido = BarraDeBusquedaEmpleadoTextBox.Text;
                    break;
                case 3: // Telefono
                    usuario.Telefono = BarraDeBusquedaEmpleadoTextBox.Text;
                    break;
                default:
                    // Si no se selecciona ningún filtro válido, puedes retornar o manejar el caso
                    return;
            }

            var selectedTab = tabControlGuna.SelectedTab;

            if (selectedTab.Text == "Activos")
            {
                Lista = usuarioBL.BuscarEmpleadosActivos(usuario);
                CargarLista();
                CargarTarjetas();

            }
            if (selectedTab.Text == "Inactivos")
            {

                Lista = usuarioBL.BuscarEmpleadosInactivos(usuario);
                CargarLista();
                CargarTarjetas();

            }
        }

        private void FiltroEmpleadoComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BarraDeBusquedaEmpleadoTextBox.Text = "";
        }

        private void listaEmpleadosDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AgregarEmpleadoPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
    

