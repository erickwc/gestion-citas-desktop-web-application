using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class ClienteBL
    {
        public Cliente ObtenerPorId(byte pIdCliente)
        {
            return ClienteDAL.ObtenerPorId(pIdCliente);
        }

        public int Guardar(Cliente pCliente)
        {
            return ClienteDAL.Guardar(pCliente);
        }

        public List<Cliente> Buscar(Cliente pCliente)
        {
            return ClienteDAL.Buscar(pCliente);
        }
    }

}