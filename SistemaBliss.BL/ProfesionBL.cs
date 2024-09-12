using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//REFERENCIAS 
using System.Security.Cryptography;
using SistemaBliss.EN;
using SistemaBliss.DAL;

namespace SistemaBliss.BL
{
    public class ProfesionBL
    {
      
        
        public int Guardar(Profesión pProfesion)
        {
            return ProfesionDAL.Guardar(pProfesion);
        }

        public int Modificar(Profesión pProfesion)
        {
            return ProfesionDAL.Modificar(pProfesion);
        }
        public Profesión ObtenerPorId(byte pProfesion)
        {
            return ProfesionDAL.ObtenerPorId(pProfesion);
        }
        public  List<Profesión> Buscar(Profesión pProfesion)
        {
            return ProfesionDAL.Buscar(pProfesion);
        }

        public List<Profesión> BuscarSinParametro()
        {
            return ProfesionDAL.BuscarSinParametro();
        }
    }
}
