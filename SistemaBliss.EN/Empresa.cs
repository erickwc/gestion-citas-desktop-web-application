using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Empresa
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdEmpresa { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }

        [Display(Name = "Telefono")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El número de teléfono debe contener 8 dígitos.")]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electronico")]
        [EmailAddress(ErrorMessage = "Ingresa un correo electronico valido")]
        public string CorreoElectronico { get; set; }
    }
}
