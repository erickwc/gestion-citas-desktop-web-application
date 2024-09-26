using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class ProfesionController : Controller
    {
        ProfesionBL profesionBL = new ProfesionBL();

        // GET: Profesion
        public ActionResult Index()
        {
            List<Profesion> profesiones = profesionBL.BuscarSinParametro();
            ViewBag.Profesiones = profesiones;

            return View(profesiones); // Devuelve las profesiones como modelo
        }


        // Nueva acción que devuelve la vista parcial
        public ActionResult ListaProfesiones()
        {
            List<Profesion> profesiones = profesionBL.BuscarSinParametro(); // Obtener las profesiones
            return PartialView("_ListaProfesiones", profesiones);
        }

        // GET: Profesion/Create
        public ActionResult Create()
        {
            return PartialView("Create", new Profesion());
        }

        // POST: Profesion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesion pProfesion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = profesionBL.Guardar(pProfesion);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro guardado.";
                        return RedirectToAction("Index", "Empleado");
                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un registro con el mismo nombre.");
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

            return View("Index"); // Asegúrate de redirigir a la vista adecuada
        }


        // GET: Profesion/Edit/5
        public ActionResult Edit()
        {
            return PartialView("Edit", new Profesion());
        }

        // POST: Profesion/Edit/5
        [HttpPost]
        public ActionResult Edit(Profesion pProfesion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = profesionBL.Modificar(pProfesion);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro actualizado.";
                        return RedirectToAction("Index", "Empleado");
                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al actualizar, intente de nuevo o contacte al soporte.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View("Index");
        }

        
    }
}
