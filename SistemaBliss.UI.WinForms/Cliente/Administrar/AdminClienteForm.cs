using System;
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
    public partial class AdminClienteForm : Form
    {
        public AdminClienteForm()
        {
            InitializeComponent();
        }

        NavegacionUI navegacionUI = new NavegacionUI();

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            navegacionUI.AbrirFormEnPanel(typeof(AgregarClienteForm), "Estadistica Completa");
        }
    }
}
