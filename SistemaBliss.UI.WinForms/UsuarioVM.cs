using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaBliss.EN;

namespace SistemaBliss.UI.WinForms
{
    public class UsuarioVM
    {
        public UsuarioVM(Usuario pUsuario)
        {
            // Logica del constructor para cargar propiedades// Logica del constructor para cargar propiedades
            this.IdUsuario = pUsuario.IdUsuario;
            this.Nombre = pUsuario.Nombre;
            this.Apellido = pUsuario.Apellido;
            this.Telefono = pUsuario.Telefono;

            // Cargar propiedad virtual mediante validacion con operador condicional ternario
            this.Estado = (pUsuario.Estado != null ? pUsuario.Estado.Nombre : "N/A");
            this.Rol = (pUsuario.Rol != null ? pUsuario.Rol.Nombre : "N/A");
        }

        // Propiedades a mostrar, ya ordenadas
        public int IdUsuario { get; set; }
        public string Rol { get; set; }
        public byte IdDepartamento { get; set; }
        public Int16 IdMunicipio { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }
        public string Dui { get; set; }
        public string Direccion { get; set; }
        public string UrlImagen { get; set; }
    }
}
