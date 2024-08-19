using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBliss.UI.WinForms
{
    internal class NavegacionUI
    {
        public void AbrirFormEnPanel(Type formType, string NombreSeccion)
        {
            AdminDashboardForm dashboard = Application.OpenForms["AdminDashboardForm"] as AdminDashboardForm;

            // Busca el formulario dentro del panel
            Form formToShow = dashboard.mainPanel.Controls.OfType<Form>().FirstOrDefault(f => f.GetType() == formType);

            if (formToShow == null)
            {
                // Si el formulario no existe, créalo y configúrelo
                formToShow = (Form)Activator.CreateInstance(formType);
                formToShow.TopLevel = false;
                formToShow.FormBorderStyle = FormBorderStyle.None;
                formToShow.Dock = DockStyle.Fill;
                dashboard.mainPanel.Controls.Add(formToShow);
                dashboard.mainPanel.Tag = formToShow;
            }

            // Limpia el contenido anterior del panel
            foreach (Control control in dashboard.mainPanel.Controls)
            {
                if (control != formToShow)
                {
                    control.Dispose();
                }
            }

            formToShow.Show();
            formToShow.BringToFront();


        }
    }
}
