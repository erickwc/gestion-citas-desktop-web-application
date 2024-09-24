using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class CitaController : Controller
    {
        CitaBL citaBL = new CitaBL();
        public ActionResult Index()
        {
            return View();
        }

        public static List<SelectListItem> DropDownListCliente(int pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Cita> lista = new CitaBL().BuscarClientes(new Cita { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Cliente).Select(x => new SelectListItem
            {
                Value = x.IdUsuario.ToString(), // PK
                Text = x.Cliente,
                Selected = (x.IdUsuario == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListEstados(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Estado> lista = new EstadoBL().BuscarEstadosCitas(new Estado { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdEstado.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }

        public List<Servicio> ListaProductos(byte pIdServicio = 0)
        {
            List<Servicio> lista = new List<Servicio>();
            lista = new ServicioBL().BuscarServiciosCita(new Servicio { IdServicio = pIdServicio });
            lista = lista.OrderBy(x => x.Nombre).ToList();
            return lista;
        }

        //public static List<SelectListItem> DropDownListServicios(byte pId = 0)
        //{
        //    List<SelectListItem> options = new List<SelectListItem>
        //        {
        //                new SelectListItem { Value = null, Text = "Seleccionar" }
        //        };

        //    // Buscar registros en la DB
        //    List<Servicio> lista = new ServicioBL().BuscarServiciosCita(new Servicio { });

        //    // Agregar opciones
        //    options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
        //    {
        //        Value = x.IdServicio.ToString(), // PK
        //        Text = x.Nombre,
        //        Selected = (x.IdEstado == pId),
        //    }).ToList());

        //    return options;
        //}

        public static List<SelectListItem> DropDownListEmpleados(int pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Usuario> lista = new UsuarioBL().BuscarEmpleadosCita(new Usuario { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdUsuario.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListEstadosDetalleCita(int pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Estado> lista = new EstadoBL().BuscarEstadosDetallesCitas(new Estado { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdEstado.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }
    }
}