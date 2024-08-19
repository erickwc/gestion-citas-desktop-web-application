using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Servicio
    {
        public byte IdServicio { get; set; }
        public byte IdCategoriaServicio { get; set; }

        public byte IdEstado { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public byte DiasAnticipacion { get; set; }
        public string Restricciones { get; set; }
        public decimal Precio { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Imagen { get; set; }


        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual CategoriaServicio CategoriaServicio { get; set; }
        public virtual Estado Estado { get; set; }
    }
}