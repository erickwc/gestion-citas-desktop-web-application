using SistemaBliss.BL;
using SistemaBliss.EN;
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

namespace SistemaBliss.UI.WinForms
{
    public partial class AdminProfesionForm : Form
    {
        public AdminProfesionForm()
        {
            InitializeComponent();
        }



        ValidacionCampos validacionCampos = new ValidacionCampos();
        ProfesionBL profesionBL = new ProfesionBL();
        public byte idUsuario;
        List<Profesión> lista = new List<Profesión>();

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (profesionTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(profesionTextBox);
                camposValidos = false;
            }
            
            return camposValidos;
        }

        private void CargarLista()
        {
            lista = profesionBL.BuscarSinParametro();
            listaProfesionesDataGridView.DataSource = "";
            listaProfesionesDataGridView.DataSource = lista;


            listaProfesionesDataGridView.Columns["IdProfesión"].Visible = false;

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            int resultado = 0; // resultado del comando en la DB
            try
            {
                if (ValidarCampos() == true)
                {

                    // Capturar datos del formulario
                    Profesión profesion = new Profesión(); // instancia de empleado
                    profesion.Nombre = profesionTextBox.Text;
                 

                    if (idUsuario == 0)
                    {
                        resultado = profesionBL.Guardar(profesion); // Se está guardando un nuevo empleado
                        
                    }
                    else
                    {
                        profesion.IdProfesión = idUsuario;
                        resultado = profesionBL.Modificar(profesion); // Se está modificando un empleado existente
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

        private void AdminProfesionForm_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void editarButton_Click(object sender, EventArgs e)
        {

            short idTabla = (short)ToolsForm.ObtenerIdGrid(listaProfesionesDataGridView);
            if (idTabla > 0)
            {
                idUsuario = Convert.ToByte(idTabla);
                string nombreRegistro = listaProfesionesDataGridView.SelectedRows[0].Cells["Nombre"].Value.ToString();

                profesionTextBox.Text = nombreRegistro;

                CargarLista();
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar el registro que desea editar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        
        }
    }
}
