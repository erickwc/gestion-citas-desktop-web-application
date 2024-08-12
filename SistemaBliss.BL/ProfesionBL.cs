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
        private static string CifrarHashSha256(string pTexto)
        {
            // Metodo para cifrar las claves
            byte[] bytes = Encoding.Unicode.GetBytes(pTexto);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        public int Guardar(Profesión pServicio)
        {
            return ProfesionDAL.Guardar(pServicio);
        }

        public int Modificar(Profesión pServicio)
        {
            return ProfesionDAL.Modificar(pServicio);
        }

        
    }
}
