using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Referencias
using System.Windows.Forms;

namespace SistemaBliss.UI.WinForms
{

    public class ToolsForm
    {
        public static long ObtenerIdGrid(DataGridView pDataGridView)
    {
        // Metodo para obtener el id de registro seleccionado en un DataGridView
        try
        {
            long idTabla = 0;
            // Obtener la PK del registro seleccionado
            idTabla = Convert.ToInt64(pDataGridView.Rows[pDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
            return idTabla;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public static DialogResult MessageBoxConfirmar()
    {
        return MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}

namespace ToolsForms
{
    public static class MyExtensions
    {
        public static bool ValidarControl(this ErrorProvider errorProvider, Control pControl, string pMensaje, string pRegex = null)
        {
            if (pControl is TextBox)
            {
                if (pControl.Text == null || pControl.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(pControl, pMensaje);
                    return false; // dato invalido
                }
                if (pRegex != null && pRegex.Trim() != "")
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(pControl.Text, pRegex))
                    {
                        errorProvider.SetError(pControl, "Formato invalido");
                        return false; // formato invalido
                    }
                }
            }
            if (pControl is ComboBox && ((ComboBox)pControl).SelectedIndex <= 0)
            {
                errorProvider.SetError(pControl, pMensaje);
                return false; // dato invalido
            }
            return true; // dato valido
        }
    }
}
