using SistemaBliss.DAL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBliss.BL
{
    public class ServicioBL
    {

        public int Guardar(Servicio pServicio)
        {
            return ServicioDAL.Guardar(pServicio);
        }

        public int Modificar(Servicio pServicio)
        {
            return ServicioDAL.Modificar(pServicio);
        }

        public Servicio ObtenerPorId(short pIdServicio)
        {
            return ServicioDAL.ObtenerPorId(pIdServicio);
        }

        public List<Servicio> BuscarServiciosActivos(Servicio pServicio)
        {
            return ServicioDAL.BuscarServiciosActivos(pServicio);
        }

        public List<Servicio> BuscarServiciosInactivos(Servicio pServicio)
        {
            return ServicioDAL.BuscarServiciosInactivos(pServicio);
        }

        public void CargarEstadoVirtual(List<Servicio> pLista, Action<List<Estado>> pAccion = null)
        {
            // Método para cargar los datos de la propiedad virtual de Cargo
            if (pLista.Count > 0)
            {
                // Obtener array de ids de estado de la lista de usuarios
                byte[] arrayIdEstado = pLista.Select(x => x.IdEstado).Distinct().ToArray();

                // Crear Diccionario de Estados buscando en la base de datos
                Dictionary<byte, Estado> diccionario = EstadoDAL.ObtenerDiccionario(arrayIdEstado);



                // Bucle para validar los Cargos e inyectarlo a los Empleados en su propiedad virtual
                foreach (var item in pLista)
                {
                    // Verificar si existe el Cargo en el diccionario
                    if (diccionario.ContainsKey(item.IdEstado) == true)
                    {
                        // Si existe, inyectar el Cargo desde el diccionario
                        item.Estado = diccionario[item.IdEstado];
                    }
                }

                // Accion auxiliar para sobrecargar otra propiedad virtual dentro de la clase Cargo
                if (pAccion != null && diccionario.Count > 0)
                {
                    pAccion(diccionario.Select(x => x.Value).ToList());
                }
            }
        }


        public void CargarCategoriaVirtual(List<Servicio> pLista, Action<List<CategoriaServicio>> pAccion = null)
        {
            // Método para cargar los datos de la propiedad virtual de Cargo
            if (pLista.Count > 0)
            {
                // Obtener array de ids de estado de la lista de usuarios
                byte[] arrayIdCategoria = pLista.Select(x => x.IdCategoriaServicio).Distinct().ToArray();

                // Crear Diccionario de Estados buscando en la base de datos
                Dictionary<byte, CategoriaServicio> diccionario = CategoriaServicioDAL.ObtenerDiccionario(arrayIdCategoria);

                // Bucle para validar los Cargos e inyectarlo a los Empleados en su propiedad virtual
                foreach (var item in pLista)
                {
                    // Verificar si existe el Cargo en el diccionario
                    if (diccionario.ContainsKey(item.IdCategoriaServicio))
                    {
                        // Si existe, inyectar el Cargo desde el diccionario en una propiedad virtual de la clase
                        item.CategoriaServicio = diccionario[item.IdCategoriaServicio];
                    }
                }

                // Acción auxiliar para sobrecargar otra propiedad virtual dentro de la clase Cargo
                if (pAccion != null && diccionario.Count > 0)
                {
                    pAccion(diccionario.Select(x => x.Value).ToList());
                }
            }
        }



    }
}