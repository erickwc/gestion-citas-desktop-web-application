using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBliss.UI.AppWebMVC.App_Start
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class AuthorizeCustom : AuthorizeAttribute
    {
        // atributos
        private string cargoSesion;
        private string nombresCargo;

        public AuthorizeCustom(string pNombresCargo)
        {
            // constructor
            nombresCargo = pNombresCargo;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                cargoSesion = (string)HttpContext.Current.Session["rol"];
                if (cargoSesion == null)
                {
                    // No ha inicio sesion el usuario, redireccionar
                    filterContext.Result = new RedirectResult("~/Auth/Index?mensaje=401 - Acceso denegado");
                }
                else
                {
                    // Existe un usuario en sesion, verificar nivel acceso del cargo
                    if (nombresCargo.ToUpper().Contains(cargoSesion.ToUpper()) == false)
                    {
                        // Usuario no tiene acceso, redireccionar
                        filterContext.Result = new RedirectResult("~/Auth/Index?mensaje=401 - Acceso denegado");
                        HttpContext.Current.Session.Abandon();
                    }
                }
            }
            catch (Exception ex)
            {
                // error interno en el servidor
                filterContext.Result = new RedirectResult("~/Auth/Index?mensaje=500 - Error interno en el servidor");
            }
        }
    }
}