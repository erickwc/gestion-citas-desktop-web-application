using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaBliss.EN;
using SistemaBliss.BL;
using System.Web.Security;
using System.Web.Services.Description;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class AuthController : Controller
    {
        UsuarioBL usuarioBL = new UsuarioBL();
        public ActionResult Index(string mensaje = null)
        {
            ViewBag.mensaje = mensaje;

            FormsAuthentication.SignOut();

            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Index(Usuario pEmpleado)
        {
            if (pEmpleado == null)
            {
                return View(new Usuario());
            }
            // Validar credenciales del usuario a autenticar
            Usuario empleadoSesion = usuarioBL.AutenticarCredenciales(pEmpleado);

            if (empleadoSesion != null && empleadoSesion.IdUsuario > 0)
            {
                // Guardar en sesion los datos del Empleado
                Session["usuario"] = empleadoSesion;

                // Obtener y guardar en sesion el nivel de acceso del empleado
                Rol cargo = new RolBL().ObtenerPorId(empleadoSesion.IdRol);
                Session["rol"] = cargo.Nombre;

                // Guardar la sesion del empleado
                FormsAuthentication.RedirectFromLoginPage(empleadoSesion.Telefono, false);
                return RedirectToAction("Index", "Cita");
            }
            else
            {
                ViewBag.mensaje = "Credenciales incorrectas";
            }

            return View(pEmpleado);
        }

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Auth");
        }
    }
}