using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.EN
{
    public class HorariosEmpresa
    {
        public byte IdHorariosEmpresa { get; set; }
        public byte IdEmpresa { get; set; }
        public string Dias { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }


        // Propiedades virtuales para llaves foraneas (FK) para representar la Asociacion
        public virtual Empresa Empresa { get; set; }
    }
}
