using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaBliss.EN;
using SistemaBliss.BL;
using Guna.UI2.WinForms;

namespace SistemaBliss.UI.WinForms
{
    public partial class AgregarClienteForm : Form
    {
        ValidacionCampos validacionCampos = new ValidacionCampos();
        public short idUsuario;
        UsuarioBL usuarioBL = new UsuarioBL();

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (nombresTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(nombresTextBox);
                camposValidos = false;
            }
            if (apellidoTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(apellidoTextBox);
                camposValidos = false;
            }
            if (direccionTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(direccionTextBox);
                camposValidos = false;
            }
            if (telefonoTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(telefonoTextBox);
                camposValidos = false;
            }
            if (departamentosComboBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(departamentosComboBox);
                camposValidos = false;
            }
            if (municipioComboBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(municipioComboBox);
                camposValidos = false;
            }
            if (duiTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(duiTextBox);
                camposValidos = false;
            }
            return camposValidos;
        }

        public void CargarMunicipios()
        {
            // Conexion a la tabla de Cargo en la DB
            MunicipioBL municipioBL = new MunicipioBL();

            // Inicializar lista 
            List<Municipio> municipios = new List<Municipio>();
            municipios.Add(new Municipio { IdMunicipio = 0, Nombre = "SELECCIONAR" });

            // Obtener lista de Cargos de la DB
            municipios.AddRange(municipioBL.Buscar(new Municipio()));
            municipioComboBox.DataSource = municipios;

            // Configurar texto y valor de la lista de seleccion
            municipioComboBox.DisplayMember = "Nombre";
            municipioComboBox.ValueMember = "IdMunicipio";
        }
        public void CargarDepartamento()
        {
            // Conexion a la tabla de Cargo en la DB
            DepartamentoBL departamentoBL = new DepartamentoBL();

            // Inicializar lista 
            List<Departamento> departamentos = new List<Departamento>();
            departamentos.Add(new Departamento { IdDepartamento = 0, Nombre = "SELECCIONAR" });

            // Obtener lista de Cargos de la DB
            departamentos.AddRange(departamentoBL.Buscar(new Departamento()));
            departamentosComboBox.DataSource = departamentos;

            // Configurar texto y valor de la lista de seleccion
            departamentosComboBox.DisplayMember = "Nombre";
            departamentosComboBox.ValueMember = "IdDepartamento";
        }
        public void CargarRol()
        {
            // Conexion a la tabla de Cargo en la DB
            RolBL rolBL = new RolBL();

            // Inicializar lista 
            List<Rol> rols = new List<Rol>();
            rols.Add(new Rol { IdRol = 0, Nombre = "SELECCIONAR" });

            // Obtener lista de Cargos de la DB
            rols.AddRange(rolBL.Buscar(new Rol()));
            RolComboBox.DataSource = rols;

            // Configurar texto y valor de la lista de seleccion
            RolComboBox.DisplayMember = "Nombre";
            RolComboBox.ValueMember = "IdRol";
        }
        public void CargarEstado()
        {
            // Conexion a la tabla de Cargo en la DB
            EstadoBL estadoBL = new EstadoBL();

            // Inicializar lista 
            List<Estado> estados = new List<Estado>();
            estados.Add(new Estado { IdEstado = 0, Nombre = "SELECCIONAR" });

            // Obtener lista de Cargos de la DB
            estados.AddRange(estadoBL.Buscar(new Estado()));
            estadoComboBox.DataSource = estados;

            // Configurar texto y valor de la lista de seleccion
            estadoComboBox.DisplayMember = "Nombre";
            estadoComboBox.ValueMember = "IdEstado";
        }

        public AgregarClienteForm()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void DepartamentoAggClienteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarClienteButton_Click(object sender, EventArgs e)
        {
            int resultado = 0; // resultado del comando en la DB
            try
            {
                if (ValidarCampos() == true)
                {

                    // Capturar datos del formulario
                    Usuario usuario = new Usuario(); // instancia de empleado
                    usuario.Nombre = nombresTextBox.Text;
                    usuario.Apellido = apellidoTextBox.Text;
                    usuario.Telefono = telefonoTextBox.Text;
                    usuario.Contrasena = contrasenaEmpleadoTextBox.Text;
                    usuario.CorreoElectronico = correoElectronicoTextBox.Text;
                    usuario.Dui = duiTextBox.Text;
                    usuario.Direccion = direccionTextBox.Text;
                    usuario.UrlImagen = "foto"; ;

                    // Convertir los valores seleccionados en los ComboBox al tipo adecuado
                    usuario.IdRol = 2;
                    usuario.IdDepartamento = Convert.ToByte(departamentosComboBox.SelectedValue);
                    usuario.IdEstado = Convert.ToByte(estadoComboBox.SelectedValue);
                    usuario.IdMunicipio = Convert.ToInt16(municipioComboBox.SelectedValue);

                    if (idUsuario == 0)
                    {
                        resultado = usuarioBL.Guardar(usuario); // Se está guardando un nuevo empleado
                    }
                    else
                    {
                        usuario.IdUsuario = idUsuario;
                        resultado = usuarioBL.Modificar(usuario); // Se está modificando un empleado existente
                    }
                    // Verificación del resultado en la base de datos
                    if (resultado > 0)
                    {
                        UsuarioBL usuarioBL = new UsuarioBL();
                        usuario = usuarioBL.ObtenerUltimoIdUsuario(correoElectronicoTextBox.Text);

                        ClienteBL clienteBL = new ClienteBL();
                        Cliente cliente = new Cliente();
                        cliente.IdUsuario = usuario.IdUsuario;
                        cliente.ServiciosAcumulados = Convert.ToInt32(citasAcumuladasTextBox.Text);

                        clienteBL.Guardar(cliente);



                        MessageBox.Show("Registro guardado exitosamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error, por favor inténtelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarClienteForm_Load(object sender, EventArgs e)
        {

            CargarMunicipios();
            CargarDepartamento();
            CargarEstado();
            CargarRol();

            if (idUsuario > 0)
            {
                // Si "idEmpleado" es mayor que cero se esta modificando un empleado
                Usuario usuario = usuarioBL.ObtenerPorId(idUsuario); // buscar por id al empleado
                Cliente cliente = new Cliente();
                ClienteBL clienteBL = new ClienteBL();
                cliente = clienteBL.ObtenerPorId(idUsuario);

                // Cargar datos del empleado en los controles del formulario
                nombresTextBox.Text = usuario.Nombre;
                apellidoTextBox.Text = usuario.Apellido;
                duiTextBox.Text = usuario.Dui;
                telefonoTextBox.Text = usuario.Telefono;
                direccionTextBox.Text = usuario.Direccion;
                correoElectronicoTextBox.Text = usuario.CorreoElectronico;
                departamentosComboBox.SelectedValue = usuario.IdRol;
                municipioComboBox.SelectedValue = usuario.IdMunicipio;
                estadoComboBox.SelectedValue = usuario.IdEstado;
                RolComboBox.SelectedValue = usuario.IdRol;
                citasAcumuladasTextBox.Text = Convert.ToString(cliente.ServiciosAcumulados);

                usuario.IdRol = Convert.ToByte(RolComboBox.SelectedValue);

                IndicacionResgistroCliente.Text = "Edita un cliente existente";
                IndicacionAgregarCliente.Text = "Edita los campos para actualizar la informacion del cliente";

                contrasenaEmpleadoTextBox.Enabled = false;
            }
        }

        private void NombresAggClienteTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelarClienteButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nombresTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Cancelar el evento si la tecla presionada no es un dígito ni la tecla de retroceso
                e.Handled = true;
            }

            // Limitar la longitud a 8 caracteres
            Guna2TextBox textBox = sender as Guna2TextBox;
            if (textBox != null && textBox.Text.Length >= 8 && e.KeyChar != (char)Keys.Back)
            {
                // Cancelar el evento si se han ingresado 8 caracteres y se presiona una tecla
                e.Handled = true;
            }
        }

        private void duiTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void duiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Cancelar el evento si la tecla presionada no es un dígito ni la tecla de retroceso
                e.Handled = true;
            }

            // Limitar la longitud a 8 caracteres
            Guna2TextBox textBox = sender as Guna2TextBox;
            if (textBox != null && textBox.Text.Length >= 9 && e.KeyChar != (char)Keys.Back)
            {
                // Cancelar el evento si se han ingresado 8 caracteres y se presiona una tecla
                e.Handled = true;
            }
        }


        private void apellidoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Cancelar el evento si la tecla presionada no es una letra ni la tecla de retroceso
                e.Handled = true;
            }
        }
    }
}
