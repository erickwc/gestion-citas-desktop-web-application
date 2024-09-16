
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias
using System.ComponentModel.DataAnnotations;


namespace SistemaBliss.EN
{
    public class CategoriaProducto
    {
        [Display(Name = "Id")]
        public byte IdCategoriaProducto { get; set; }

        [Display(Name = "Id")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
    }
}
