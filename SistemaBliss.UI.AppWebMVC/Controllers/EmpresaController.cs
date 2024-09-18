using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaBliss.EN;
using SistemaBliss.BL;
using System.Net;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class EmpresaController : Controller
    {
        EmpresaBL empresaBL = new EmpresaBL();
        // GET: Empresa
        public ActionResult Index(Empresa pEmpresa)
        {
            if (pEmpresa == null)
            {
                pEmpresa = new Empresa();
            }
            List<Empresa> lista = empresaBL.Buscar(pEmpresa);
            return View(lista);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: Empresa/Edit/5
        public ActionResult Edit()
        {
            Empresa empresa = empresaBL.ObtenerPorId(1);
            return View(empresa);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa pEmpresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = empresaBL.Modificar(pEmpresa);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro actualizado.";
                        return RedirectToAction("Edit", "Empresa");
                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un registro con el mismo teléfono.");
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

            return View(pEmpresa);
        }



    }
}