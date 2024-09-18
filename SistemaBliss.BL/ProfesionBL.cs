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
      
        
        public int Guardar(Profesion pProfesion)
        {
            return ProfesionDAL.Guardar(pProfesion);
        }

        public int Modificar(Profesion pProfesion)
        {
            return ProfesionDAL.Modificar(pProfesion);
        }
        public Profesion ObtenerPorId(byte pProfesion)
        {
            return ProfesionDAL.ObtenerPorId(pProfesion);
        }
        public  List<Profesion> Buscar(Profesion pProfesion)
        {
            return ProfesionDAL.Buscar(pProfesion);
        }

        public List<Profesion> BuscarSinParametro()
        {
            return ProfesionDAL.BuscarSinParametro();
        }
    }
}
