using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias
using System.ComponentModel.DataAnnotations;

namespace SistemaBliss.EN
{
    public class Usuario
    {
        [Display(Name = "Id")]
        public int IdUsuario { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdRol { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdDepartamento { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public Int16 IdMunicipio { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdEstado { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Apellido { get; set; }

        [Display(Name = "Telefono")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El número de teléfono debe contener 8 dígitos.")]
        public string Telefono { get; set; }

        [Display(Name = "Contraseña")]
        [StringLength(20, MinimumLength=8, ErrorMessage = "Este campo es requerido.")]
        public string Contrasena { get; set; }

        [Display(Name = "Correo Electronico")]
        [EmailAddress(ErrorMessage = "Ingresa un correo electronico valido")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Dui")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El número de teléfono debe contener 8 dígitos.")]
        public string Dui { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Direccion { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        //Propiedades virtuales para llaves foraneas (FK) para representar la asociacion
        public virtual Rol Rol { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Municipio Municipio { get; set; }

        public bool IsPasswordEncrypted { get; set; }

        public int ClientesTotales { get; set; }
        public int ClientesActivos { get; set; }
        public int ClientesInactivos { get; set; }

        public int EmpleadosTotales { get; set; }
        public int EmpleadosActivos { get; set; }
        public int EmpleadosInactivos { get; set; }

    }
}
