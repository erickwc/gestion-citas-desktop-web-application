using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class HorarioController : Controller
    {
        HorariosEmpresaBL horarioEmpresaBL = new HorariosEmpresaBL();
        // GET: Horario

        public ActionResult HorariosLista()
        {
            List<HorariosEmpresa> horariosEmpresa = horarioEmpresaBL.Buscar();
            return PartialView("_Horarios", horariosEmpresa);
        }

        // GET: Horario/Create
        public ActionResult Create()
        {
            return PartialView("Create", new HorariosEmpresa());
        }

        // POST: Horario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HorariosEmpresa pHorariosEmpresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = horarioEmpresaBL.Guardar(pHorariosEmpresa);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro guardado.";
                        return RedirectToAction("Edit", "Empresa");
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

            return View(); 
        }

        // GET: Horario/Edit/5
        public ActionResult Edit()
        {
            return PartialView("Edit", new HorariosEmpresa());
        }

        // POST: Horario/Edit/5
        [HttpPost]
        public ActionResult Edit(HorariosEmpresa pHorariosEmpresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = horarioEmpresaBL.Modificar(pHorariosEmpresa);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro actualizado.";
                        return RedirectToAction("Edit", "Empresa");
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

        // POST: Horario/Edit/5
        [HttpPost]
        public ActionResult Delete(byte id)
        {
            try
            {
                    int resultado = horarioEmpresaBL.Eliminar(new HorariosEmpresa { IdHorariosEmpresa = id });

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro eliminado.";
                        return RedirectToAction("Edit", "Empresa");
                    }
                    
                    else
                    {
                    TempData["tipo"] = "error";
                    TempData["mensaje"] = "Error al eliminar, intente de nuevo o contacte al soporte.";
                    }
               
            }
            catch (Exception ex)
            {
                TempData["tipo"] = "error";
                TempData["mensaje"] = ex.Message;
            }

            return View("Index");
        }

    }
}
