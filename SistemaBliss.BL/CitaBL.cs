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

        public Cita ObtenerPorId(int pIdCita)
        {
            return CitaDAL.ObtenerPorId(pIdCita);
        }

        public List<Cita> BuscarCitasPendientes(Cita pCita, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return CitaDAL.BuscarCitasPendientes(pCita, fechaInicio, fechaFin);
        }

        public List<Cita> BuscarCitasConfirmadas(Cita pCita, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return CitaDAL.BuscarCitasConfirmadas(pCita, fechaInicio, fechaFin);
        }

        public List<Cita> BuscarCitasFinalizadas(Cita pCita, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return CitaDAL.BuscarCitasFinalizadas(pCita, fechaInicio, fechaFin);
        }

        public List<Cita> BuscarClientes(Cita pCita)
        {
            return CitaDAL.BuscarClientes(pCita);
        }


    }
}
