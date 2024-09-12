using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class CitaBL
    {
        public int Guardar(Cita pCita)
        {
            return CitaDAL.Guardar(pCita);
        }

        public int Modificar(Cita pCita)
        {
            return CitaDAL.Modificar(pCita);
        }

        public int ObtenerPorId(Cita pIdCita)
        {
            return CitaDAL.BuscarPorId(pIdCita);
        }

        public int Buscar(Cita pIdCita)
        {
            return CitaDAL.Buscar(pIdCita);
        }



    }
}
