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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using Guna.UI2.WinForms;

namespace SistemaBliss.UI.WinForms
{
    public partial class AgregarEmpleadoForm : Form
    {
        public AgregarEmpleadoForm()
        {
            InitializeComponent();
        }

        ValidacionCampos validacionCampos = new ValidacionCampos();
        public short idUsuario;
        UsuarioBL usuarioBL = new UsuarioBL();
        List<DetalleProfesión> lista = new List<DetalleProfesión>();

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

        public void CargarProfesiones()
        {
            // Conexion a la tabla de Cargo en la DB
            ProfesionBL profesionesBL = new ProfesionBL();

            // Inicializar lista 
            List<Profesión> profesion = new List<Profesión>();
            profesion.Add(new Profesión { IdProfesión = 0, Nombre = "SELECCIONAR" });

            // Obtener lista de Cargos de la DB
            profesion.AddRange(profesionesBL.Buscar(new Profesión()));
            profesionComboBox.DataSource = profesion;

            // Configurar texto y valor de la lista de seleccion
            profesionComboBox.DisplayMember = "Nombre";
            profesionComboBox.ValueMember = "IdProfesión";
        }

        private void AgregarEmpleadoForm_Load(object sender, EventArgs e)
        {
            if (idUsuario == 0)
            {
                listaProfesionesAgregadas.Columns.Add("IdProfesion", "ID Profesión");
                listaProfesionesAgregadas.Columns.Add("NombreProfesion", "Nombre Profesión");
            }
            else if(idUsuario > 0)
            {
                //listaProfesionesAgregadas.Columns["IdProfesion"].Visible = false;
                //listaProfesionesAgregadas.Columns["IdDetalleProfesion"].Visible = false;

            }



            CargarMunicipios();
            CargarDepartamento();
            CargarEstado();
            CargarRol();
            CargarProfesiones();

            if (idUsuario > 0)
            {
                // Si "idEmpleado" es mayor que cero se esta modificando un empleado
                Usuario usuario = usuarioBL.ObtenerPorId(idUsuario); // buscar por id al empleado


                // Cargar datos del empleado en los controles del formulario
                nombreTextBox.Text = usuario.Nombre;
                apellidoTextBox.Text = usuario.Apellido;
                duiTextBox.Text = usuario.Dui;
                telefonoTextBox.Text = usuario.Telefono;
                direccionTextBox.Text = usuario.Direccion;
                correoElectronicoTextBox.Text = usuario.CorreoElectronico;
                departamentosComboBox.SelectedValue = usuario.IdRol; 
                municipioComboBox.SelectedValue = usuario.IdMunicipio; 
                estadoComboBox.SelectedValue = usuario.IdEstado;
                rolComboBox.SelectedValue = usuario.IdRol;

                usuario.IdRol = Convert.ToByte(rolComboBox.SelectedValue);

                RegistroEmpleadoLabel.Text = "Edita un empleado existente";
                IntruccionNuevoEmpLabel.Text = "Edita los campos para actualizar la informacion del empleado";

                contrasenaTextBox.Enabled = false;
                CargarLista();


            }

        }

        private void CargarLista()
        {
            DetalleProfesionBL detalleProfesionBL = new DetalleProfesionBL();
            List<DetalleProfesión> lista = detalleProfesionBL.Buscar(idUsuario);

            listaProfesionesAgregadas.DataSource = null; // Limpiar el DataGridView
            listaProfesionesAgregadas.DataSource = lista; // Asignar la nueva lista

            listaProfesionesAgregadas.Columns["IdProfesion"].Visible = false;
            listaProfesionesAgregadas.Columns["IdDetalleProfesion"].Visible = false;
            listaProfesionesAgregadas.Columns["NombreProfesion"].Visible = true;

            // Asegúrate de que estas columnas existan en el DataGridView
            listaProfesionesAgregadas.Columns["IdUsuario"].Visible = false;
            listaProfesionesAgregadas.Columns["Usuario"].Visible = false;
            listaProfesionesAgregadas.Columns["Profesión"].Visible = false;
            //listaProfesionesAgregadas.Columns["ID Profesión"].Visible = false;
            //listaProfesionesAgregadas.Columns["Nombre Profesión"].Visible = false;
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
                    usuario.IdRol = 1;
                    usuario.IdDepartamento = Convert.ToByte(departamentosComboBox.SelectedValue);
                    usuario.IdEstado = Convert.ToByte(estadoComboBox.SelectedValue);
                    usuario.IdMunicipio = Convert.ToInt16(municipioComboBox.SelectedValue);

                    if (idUsuario == 0)
                    {
                        resultado = usuarioBL.Guardar(usuario); // Se está guardando un nuevo empleado

                        foreach (DataGridViewRow row in listaProfesionesAgregadas.Rows)
                        {
                            // Obtén el IdProfesion o la profesión (dependiendo de cómo la tienes en el DataGridView)
                            int idProfesion = Convert.ToInt32(row.Cells["IdProfesion"].Value);


                            UsuarioBL usuarioBL = new UsuarioBL();
                            usuario = usuarioBL.ObtenerUltimoIdUsuario(correoElectronicoTextBox.Text);


                            // Crea una instancia de DetalleProfesión
                            DetalleProfesión detalleProfesion = new DetalleProfesión();
                            detalleProfesion.IdProfesion = idProfesion;
                            detalleProfesion.IdUsuario = usuario.IdUsuario;

                            // Guarda la relación entre el empleado y la profesión
                            DetalleProfesionBL.Guardar(detalleProfesion);
                        }
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void departamentosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                    }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int resultado = 0;

            if (idUsuario == 0)
            {
                if (listaProfesionesAgregadas.SelectedRows.Count > 0)
                {
                    int rowIndex = listaProfesionesAgregadas.SelectedRows[0].Index;
                    listaProfesionesAgregadas.Rows.RemoveAt(rowIndex);
                }
                else
                {
                    MessageBox.Show("Seleccione una fila para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (listaProfesionesAgregadas.SelectedRows.Count > 0)
                {
                    int idProfesion = Convert.ToInt32(listaProfesionesAgregadas.SelectedRows[0].Cells["IdDetalleProfesion"].Value);

                    resultado = DetalleProfesionBL.Eliminar(idProfesion);
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar el registro que desea eliminar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }

        private void agregarProfesionButton_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            if (idUsuario == 0)
            {
                // Paso 2: Obtener la opción seleccionada del ComboBox como objeto
                var profesionSeleccionada = profesionComboBox.SelectedItem as Profesión;

                // Paso 3: Verificar que no sea null y agregar la propiedad deseada al DataGridView
                if (profesionSeleccionada != null)
                {
                    // Agregar tanto el ID como el Nombre de la profesión al DataGridView
                    listaProfesionesAgregadas.Rows.Add(profesionSeleccionada.IdProfesión, profesionSeleccionada.Nombre);
                }
            }
            else
            {
                DetalleProfesión detalleProfesion = new DetalleProfesión(); // instancia de empleado
                detalleProfesion.IdUsuario = idUsuario;
                detalleProfesion.IdProfesion = Convert.ToInt32(profesionComboBox.SelectedValue);
                
                resultado = DetalleProfesionBL.Guardar(detalleProfesion);

                CargarLista();

            }
                
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

        private void nombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Cancelar el evento si la tecla presionada no es una letra ni la tecla de retroceso
                e.Handled = true;
            }
        }
    }
}
