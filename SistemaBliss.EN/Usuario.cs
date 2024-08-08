using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public byte IdRol { get; set; }
        public byte IdDepartamento { get; set; }
        public short IdMunicipio { get; set; }
        public byte IdEstado { get; set; }
        public string Nombre { get; set;}
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public byte[] Contraseña { get; set; }
        public string CorreoElectronico { get; set; }
        public string Dui { get; set; }
        public string Direccion { get; set; }
        public byte[] UrlImagen { get; set; }

        //Propiedades virtuales para llaves foraneas (FK) para representar la asociacion
        public virtual Rol Rol { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
