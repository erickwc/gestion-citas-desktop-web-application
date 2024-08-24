using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBliss.UI.WinForms
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        ValidacionCampos validacionCampos = new ValidacionCampos();
        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (telefonoTextBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(telefonoTextBox);
                camposValidos = false;
            }
            if (contraseñaTexBox.Text.Length == 0)
            {
                validacionCampos.CampoInvalidoAparienciaTextBox(contraseñaTexBox);
                camposValidos = false;
            }
            return camposValidos;
        }

        private static string CifrarHashSha256(string pTexto)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pTexto);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }
            return hashString;
        }

       

        private void iniciarSesionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == true)
                {

                    UsuarioBL usuarioBL = new UsuarioBL();
                    Usuario usuario = new Usuario();

                    usuario = usuarioBL.ObtenerClavePorTelefono(telefonoTextBox.Text);

                    if(usuario.Contrasena == contraseñaTexBox.Text)
                    {
                        usuarioBL.ActualizarClaveNoCifrada(usuario);

                        string contrasena = contraseñaTexBox.Text;
                        string contrasenaCifrada = CifrarHashSha256(contrasena);

                   
                        usuario = usuarioBL.ObtenerPorIdLogin(telefonoTextBox.Text, contrasenaCifrada);

                        if (usuario != null)
                        {
                            AdminDashboardForm dashboardForm = new AdminDashboardForm();
                            dashboardForm.Show();
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string contrasena = contraseñaTexBox.Text;
                        string contrasenaCifrada = CifrarHashSha256(contrasena);


                        usuario = usuarioBL.ObtenerPorIdLogin(telefonoTextBox.Text, contrasenaCifrada);

                        if (usuario != null)
                        {
                            AdminDashboardForm dashboardForm = new AdminDashboardForm();
                            dashboardForm.Show();
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





            
        }
    }
}
