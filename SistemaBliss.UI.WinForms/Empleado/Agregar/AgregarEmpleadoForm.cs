using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//REFERENCIAS
using SistemaBliss.EN;
using SistemaBliss.BL;
//REFERNCIAS
using ToolsForms;

namespace SistemaBliss.UI.WinForms
{
    public partial class AgregarEmpleadoForm : Form
    {
        public AgregarEmpleadoForm()
        {
            InitializeComponent();
        }
        ValidacionCampos validacionCampos = new ValidacionCampos();
        short idUsuario;
              UsuarioBL usuarioBL = new UsuarioBL();

        private bool ValidarCampos()
        {
            bool camposValidos = true;
           
            if (nombreTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(nombreTextBox);
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
            if (departamentoComboBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(departamentoComboBox);
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
           departamentoComboBox.DataSource = departamentos;

            // Configurar texto y valor de la lista de seleccion
            departamentoComboBox.DisplayMember = "Nombre";
            departamentoComboBox.ValueMember = "IdDepartamento";
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
            rolComboBox.DataSource = rols;

            // Configurar texto y valor de la lista de seleccion
            rolComboBox.DisplayMember = "Nombre";
            rolComboBox.ValueMember = "IdRol";
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


        private void AgregarEmpleadoForm_Load(object sender, EventArgs e)
        {
            CargarMunicipios();
            CargarDepartamento();
            CargarEstado();
            CargarRol();
            
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            int resultado = 0; // resultado del comando en la DB
            try
            {
                if (ValidarCampos() == true)
                {
                    // Capturar datos del formulario
                    Usuario usuario = new Usuario(); // instancia de empleado
                    usuario.Nombre = nombreTextBox.Text;
                    usuario.Apellido = apellidoTextBox.Text;
                    usuario.Telefono = telefonoTextBox.Text;
                    usuario.Contrasena = contrasenaTextBox.Text;
                    usuario.CorreoElectronico = correoElectronicoTextBox.Text;
                    usuario.Dui = duiTextBox.Text;
                    usuario.Direccion = direccionTextBox.Text;
                    usuario.UrlImagen = "foto"; ; 

                    // Convertir los valores seleccionados en los ComboBox al tipo adecuado
                    usuario.IdRol = Convert.ToByte(rolComboBox.SelectedValue);
                    usuario.IdDepartamento = Convert.ToByte(departamentoComboBox.SelectedValue);
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

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void RolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
