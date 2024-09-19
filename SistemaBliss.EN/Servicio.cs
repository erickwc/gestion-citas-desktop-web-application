using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class Servicio
    {
        [Display(Name = "Id")]
        public byte IdServicio { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdCategoriaServicio { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte IdEstado { get; set; }

        [Display(Name = "Nombre del servicio")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción del servicio")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripción { get; set; }

        [Display(Name = "Dias de anticipación")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public byte DiasAnticipacion { get; set; }

        [Display(Name = "Restricciones del servicio")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Restricciones { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe estar entre 0.01 y 10,000")]
        public decimal Precio { get; set; }

        [Display(Name = "Duración")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public TimeSpan Duracion { get; set; }

        [Display(Name = "Imagen")]
        public string Imagen { get; set; }


        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual CategoriaServicio CategoriaServicio { get; set; }
        public virtual Estado Estado { get; set; }
    }
}