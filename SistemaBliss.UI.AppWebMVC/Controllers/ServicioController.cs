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

        // GET: Servicio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Servicio/Edit/5
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

        // GET: Servicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Servicio/Delete/5
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
