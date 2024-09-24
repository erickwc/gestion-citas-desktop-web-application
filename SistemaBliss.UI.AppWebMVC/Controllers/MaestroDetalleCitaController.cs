using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaBliss.UI.AppWebMVC.Models.ViewModels;
using SistemaBliss.UI.AppWebMVC.Models;
using SistemaBliss.BL;
using SistemaBliss.EN;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class MaestroDetalleCitaController : Controller
    {

        CitaBL citaBL = new CitaBL();

        // GET: MaestroDetalleCita
        public ActionResult Index()
        {
            ViewBag.Clientes = DropDownListCliente();
            ViewBag.Empleados = DropDownListEmpleados();
            ViewBag.Servicios = DropDownListServicios();
            ViewBag.Estados = DropDownListEstados();

            return View();
        }

        // GET: MaestroDetalleCita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaestroDetalleCita/Create
        [HttpPost]
        public ActionResult Create(CitaViewModel pCita)
        {
            try
            {
               

            }
            catch (Exception ex)
            {
            }

            return View(pCita);
        }

        // GET: MaestroDetalleCita/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MaestroDetalleCita/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MaestroDetalleCita/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MaestroDetalleCita/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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

        public static List<SelectListItem> DropDownListServicios(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Servicio> lista = new ServicioBL().BuscarServiciosCita(new Servicio { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdServicio.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
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
    }
}
