using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaBliss.EN;
using SistemaBliss.BL;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class ProfesionController : Controller
    {
        ProfesionBL profesionBL = new ProfesionBL();

        // GET: Profesion
        public ActionResult Index()
        {
            Profesion pProfesion = new Profesion();
            List<Profesion> lista = profesionBL.BuscarSinParametro();
            return View(lista); // Pasar la lista como modelo
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
            if (ModelState.IsValid)
            {
                int resultado = profesionBL.Guardar(pProfesion);
                if (resultado > 0)
                {
                    TempData["mensaje"] = "Registro guardado.";
                    return RedirectToAction("Index"); // Redirige a la acción adecuada
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

            // Si hay errores, vuelve a mostrar el modal con errores
            return PartialView("Create", pProfesion);
        }
   



        // GET: Profesion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profesion/Edit/5
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

        
    }
}
