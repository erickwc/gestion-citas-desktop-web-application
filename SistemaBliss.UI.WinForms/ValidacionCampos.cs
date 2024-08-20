using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.UI.WinForms
{
    internal class ValidacionCampos
    {
        public void CampoInvalidoAparienciaTextBox(Guna2TextBox textBox)
        {
            if (textBox.Text.Length == 0)
            {
                textBox.FillColor = Color.MistyRose;
                textBox.BorderColor = Color.Red;
                textBox.HoverState.BorderColor = Color.Red;
                textBox.ForeColor = Color.Red;
                textBox.FocusedState.BorderColor = Color.Red;
                textBox.PlaceholderForeColor = Color.Red;
                textBox.PlaceholderText = "Este campo es obligatorio";
                //textBox.IconRight = Properties.Resources.alert_circle_img;
            }
        }

        public void CampoValidoAparienciaTextBox(Guna2TextBox textBox)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.FillColor = Color.MintCream;
                textBox.BorderColor = Color.Green;
                textBox.HoverState.BorderColor = Color.Green;
                textBox.ForeColor = Color.Green;
                textBox.FocusedState.BorderColor = Color.Green;
            }
        }

        public void CampoValidoAparienciaComboBox(Guna2ComboBox comboBox)
        {
            if (comboBox.SelectedIndex != -1)
            {
                comboBox.FillColor = Color.MintCream;
                comboBox.BorderColor = Color.Green;
                comboBox.HoverState.BorderColor = Color.Green;
                comboBox.ForeColor = Color.Green;
                comboBox.FocusedState.BorderColor = Color.Green;
            }
        }

        public void CampoInvalidoAparienciaComboBox(Guna2ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.FillColor = Color.MistyRose;
                comboBox.BorderColor = Color.Red;
                comboBox.HoverState.BorderColor = Color.Red;
                comboBox.ForeColor = Color.Red;
                comboBox.FocusedState.BorderColor = Color.Red;
            }
        }
    }
}
