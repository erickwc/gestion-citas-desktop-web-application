using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsForms;

namespace SistemaBliss.UI.WinForms
{
    public partial class AdminEmpresaForm : Form
    {
        Empresa empresa;
        EmpresaBL empresaBL = new EmpresaBL();
        HorariosEmpresaBL horariosEmpresaBL = new HorariosEmpresaBL();
        ValidacionCampos validacionCampos = new ValidacionCampos();
        List<HorariosEmpresa> lista = new List<HorariosEmpresa>();
        public byte idEmpresa = 0;
        public short idHorariosEmpresa = 0;

        public AdminEmpresaForm()
        {
            InitializeComponent();
        }

        private void CargarLista()
        {
            lista = horariosEmpresaBL.Buscar(new HorariosEmpresa { IdEmpresa = idEmpresa });
            listaHorariosDatGridView.DataSource = ""; // Vaciar DataGridView
            listaHorariosDatGridView.DataSource = lista; // Agregar objetos de lista
            listaHorariosDatGridView.Columns["IdHorariosEmpresa"].Visible = false;
            listaHorariosDatGridView.Columns["IdEmpresa"].Visible = false;
            listaHorariosDatGridView.Columns["Empresa"].Visible = false;

        }

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (nombreTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(nombreTextBox);
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
            if (correoElectronicoTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(correoElectronicoTextBox);
                camposValidos = false;
            }
            

            return camposValidos;
        }


        private bool ValidarCamposHorarios()
        {
            bool camposValidos = true;

            if (diaCombobox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(diaCombobox);
                camposValidos = false;
            }
            if (horaAperturaCombobox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(horaAperturaCombobox);
                camposValidos = false;
            }
            if (minutoAperturaCombobox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(minutoAperturaCombobox);
                camposValidos = false;
            }
            if (horaCierreCombobox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(horaCierreCombobox);
                camposValidos = false;
            }
            if (minutoCierreCombobox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaComboBox(minutoCierreCombobox);
                camposValidos = false;
            }


            return camposValidos;
        }


        private void guardarInformacionButton_Click(object sender, EventArgs e)
        {
            int resultado = 0; // resultado del comando en la DB
            try
            {
                if (ValidarCampos() == true)
                {
                    // Capturar datos del formulario
                    Empresa empresa = new Empresa(); // instancia de empleado
                    empresa.Nombre = nombreTextBox.Text;
                    empresa.Telefono = telefonoTextBox.Text;
                    empresa.Direccion = direccionTextBox.Text;
                    empresa.CorreoElectronico = telefonoTextBox.Text;

                    empresa.IdEmpresa = 1;
                    resultado = empresaBL.Modificar(empresa); 
                   
                    if (resultado > 0)
                    {
                        validacionCampos.CampoValidoAparienciaTextBox(nombreTextBox);
                        validacionCampos.CampoValidoAparienciaTextBox(telefonoTextBox);
                        validacionCampos.CampoValidoAparienciaTextBox(direccionTextBox);
                        validacionCampos.CampoValidoAparienciaTextBox(correoElectronicoTextBox);
                        MessageBox.Show("Registro guardado exitosamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error, por favor intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminEmpresaForm_Load(object sender, EventArgs e)
        {
            empresa = empresaBL.ObtenerPorId(1);
            nombreTextBox.Text = empresa.Nombre;
            direccionTextBox.Text = empresa.Direccion;
            telefonoTextBox.Text = empresa.Telefono;
            correoElectronicoTextBox.Text = empresa.CorreoElectronico;
            listaHorariosDatGridView.RowTemplate.Height = 50;
            CargarLista();
        }

        private void agregarHorarioButton_Click(object sender, EventArgs e)
        {
            int resultado = 0; // resultado del comando en la DB
            try
            {
                if (ValidarCamposHorarios() == true)
                {
                    // Capturar datos del formulario
                    HorariosEmpresa horariosEmpresa = new HorariosEmpresa(); // instancia de empleado
                    horariosEmpresa.Dias = diaCombobox.Text;
                    horariosEmpresa.IdEmpresa = 1;
                    int horaApertura = int.Parse(horaAperturaCombobox.Text);
                    int minutosEntrada = int.Parse(minutoAperturaCombobox.Text);

                    int horaCierre = int.Parse(horaCierreCombobox.Text);
                    int minutosCierre = int.Parse(minutoCierreCombobox.Text);


                    horariosEmpresa.HoraEntrada = new TimeSpan(horaApertura, minutosCierre, 0);
                    horariosEmpresa.HoraSalida = new TimeSpan(horaCierre, minutosCierre, 0);
                    

                    if (idHorariosEmpresa == 0)
                    {
                        resultado = horariosEmpresaBL.Guardar(horariosEmpresa); //Se esta guardando un nuevo empleado
                        MessageBox.Show("Horario guardado exitosamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        horariosEmpresa.IdHorariosEmpresa = Convert.ToByte(idHorariosEmpresa);
                        resultado = horariosEmpresaBL.Modificar(horariosEmpresa); //Se esta modificando un empleado existente
                        MessageBox.Show("Horario modificado exitosamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (resultado > 0)
                    {
                        diaCombobox.SelectedIndex = -1;
                        horaCierreCombobox.SelectedIndex = -1;
                        minutoCierreCombobox.SelectedIndex = -1;
                        horaAperturaCombobox.SelectedIndex = -1;
                        minutoAperturaCombobox.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error, por favor intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            short idTabla = (short)ToolsForm.ObtenerIdGrid(listaHorariosDatGridView);
            if (idTabla > 0)
            {
                // Abrir formulario para modificar el empleado seleccionado
                
                idHorariosEmpresa = idTabla;
                diaCombobox.Text = listaHorariosDatGridView.SelectedRows[0].Cells["Dias"].Value.ToString();
                string horaEntradaCompleta = listaHorariosDatGridView.SelectedRows[0].Cells["HoraEntrada"].Value.ToString();
                string horaCierreCompleta = listaHorariosDatGridView.SelectedRows[0].Cells["HoraSalida"].Value.ToString();

                TimeSpan horaEntrada = TimeSpan.Parse(horaEntradaCompleta);
                string horasEntrada = horaEntrada.Hours.ToString("D2"); // D2 para obtener dos dígitos (e.g., "08" en lugar de "8")
                string minutosEntrada = horaEntrada.Minutes.ToString("D2"); // D2 para obtener dos dígitos

                horaAperturaCombobox.Text = horasEntrada;
                minutoAperturaCombobox.Text = minutosEntrada;


                TimeSpan horaCierre = TimeSpan.Parse(horaCierreCompleta);
                string horasSalida = horaCierre.Hours.ToString("D2"); // D2 para obtener dos dígitos (e.g., "08" en lugar de "8")
                string minutosSalida = horaCierre.Minutes.ToString("D2"); // D2 para obtener dos dígitos

                horaCierreCombobox.Text = horasSalida;
                minutoCierreCombobox.Text = minutosSalida;

                // Actualizar lista simulando click en boton de BUSCAR
                

                agregarHorarioButton.Text = "Guardar cambios";
                modificarButton.Visible = false;
                eliminarButton.Visible = false;
                cancelarButton.Visible = true;
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar el registro que desea editar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            agregarHorarioButton.Text = "Agregar horarios";
            modificarButton.Visible = true;
            cancelarButton.Visible = false;
            eliminarButton.Visible = true;
        }
    }
}
