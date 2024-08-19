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

namespace SistemaBliss.UI.WinForms
{
    public partial class AgregarClienteForm : Form
    {
        // Conexion a la tabla de Clientes en la DB
        ClienteBL clienteBL = new ClienteBL();
        //Variables
        List<Cliente> Lista = new List<Cliente>();

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

        }

        private void AgregarClienteForm_Load(object sender, EventArgs e)
        {


        }

        private void NombresAggClienteTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
