using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class ServicioController : Controller
    {
        ServicioBL servicioBL = new ServicioBL();
        public ActionResult Index(Servicio pServicio)
        {

            // Obtener la lista filtrada de usuarios
            List<Servicio> lista = servicioBL.Buscar(pServicio);

            // Listas de seleccion filtros
            ViewBag.CategoriaServicio = DropDownListServicios();

            // Devolver la lista filtrada al modelo de la vista
            return View(lista);
        }



        // GET: Servicio/Create
        public ActionResult Create()
        {
            ViewBag.Roles = DropDownListServicios();
            return View();
        }

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(Servicio pServicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = servicioBL.Guardar(pServicio);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Servicio guardado.";
                        return RedirectToAction("Index");
                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un servicio con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al registrar, intente de nuevo o contacte al soporte.");
                    }

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            // Cargar lista de seleccion
            ViewBag.Roles = DropDownListServicios();
            return View();
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(byte id)
        {
            Servicio servicio = servicioBL.ObtenerPorId(id);
            // Cargar lista de seleccion
            ViewBag.Roles = DropDownListServicios();
            return View();
        }


        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Servicio pServicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = servicioBL.Modificar(pServicio);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro actualizado.";
                        return RedirectToAction("Index");
                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al registrar servicio, intente de nuevo o contacte al soporte.");
                    }

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            // Cargar lista de seleccion
            ViewBag.Roles = DropDownListServicios();
            return View();
        }

        public static List<SelectListItem> DropDownListServicios(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                  new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<CategoriaServicio> lista = new CategoriaServicioBL().Buscar(new CategoriaServicio { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdCategoriaServicio.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdCategoriaServicio == pId),
            }).ToList());

            return options;
        }
    }
}
