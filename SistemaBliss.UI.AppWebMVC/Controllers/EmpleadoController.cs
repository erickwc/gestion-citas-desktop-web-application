using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using SistemaBliss.UI.AppWebMVC.App_Start;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        [AuthorizeCustom("ADMINISTRADOR")]
        UsuarioBL usuarioBL = new UsuarioBL();
        DetalleProfesionBL detalleProfesionBL = new DetalleProfesionBL();
        public ActionResult Index(string Nombre, string campoBusqueda)
        {
            Usuario pUsuario = new Usuario();

            // Filtros basados en la selección del usuario
            switch (campoBusqueda)
            {
                case "1": // Nombres
                    pUsuario.Nombre = Nombre;
                    break;
                case "2": // Apellidos
                    pUsuario.Apellido = Nombre;
                    break;
                case "3": // Teléfono
                    pUsuario.Telefono = Nombre;
                    break;
            }

            // Obtener empleados activos e inactivos
            List<Usuario> empleadosActivos = usuarioBL.BuscarEmpleadosActivos(pUsuario);
            List<Usuario> empleadosInactivos = usuarioBL.BuscarEmpleadosInactivos(pUsuario);

            // Cargar estado y rol virtual para cada lista
            usuarioBL.CargarEstadoVirtual(empleadosActivos);
            usuarioBL.CargarRolVirtual(empleadosActivos);
            usuarioBL.CargarEstadoVirtual(empleadosInactivos);
            usuarioBL.CargarRolVirtual(empleadosInactivos);

            // Pasar las listas a la vista a través de ViewBag
            ViewBag.EmpleadosActivos = empleadosActivos;
            ViewBag.EmpleadosInactivos = empleadosInactivos;

            // Opciones del DropDownList
            List<SelectListItem> options = new List<SelectListItem>
            {
                new SelectListItem { Value = null, Text = "Seleccionar" },
                new SelectListItem { Value = "1", Text = "Nombres" },
                new SelectListItem { Value = "2", Text = "Apellidos" },
                new SelectListItem { Value = "3", Text = "Teléfono" }
            };

            ViewBag.Options = options;

            return View();
        }


        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Roles = DropDownListRoles();
            ViewBag.Estados = DropDownListEstados();
            ViewBag.Municipios = DropDownListMunicipios();
            ViewBag.Departamentos = DropDownListDepartamentos();
            ViewBag.Profesiones = DropDownListProfesiones();

            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(Usuario pUsuario)
        {
            try
            {
                if (pUsuario.UploadImage != null && pUsuario.UploadImage.ContentLength > 0)
                {
                    string strDateTime = System.DateTime.Now.ToString("ddMMyyyyHHMMss");
                    string finalPath = "\\UploadedFile\\" + strDateTime + pUsuario.UploadImage.FileName;

                    // Guardar el archivo
                    pUsuario.UploadImage.SaveAs(Server.MapPath("~") + finalPath);
                    pUsuario.UrlImagen = finalPath; // Guardar la URL de la imagen
                }
                else
                {
                    pUsuario.UrlImagen = null; 
                }

                if (ModelState.IsValid)
                {
                    int resultado = usuarioBL.Guardar(pUsuario);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro guardado.";
                        return RedirectToAction("Index");
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

            Profesion profesion = new Profesion();

            // Cargar lista de seleccion
            ViewBag.Roles = DropDownListRoles(pUsuario.IdRol);
            ViewBag.Estados = DropDownListEstados(pUsuario.IdEstado);
            ViewBag.Municipios = DropDownListMunicipios(Convert.ToByte(pUsuario.IdMunicipio));
            ViewBag.Departamentos = DropDownListDepartamentos(pUsuario.IdDepartamento);
            ViewBag.Profesiones = DropDownListProfesiones(profesion.IdProfesión);

            return View(pUsuario);
        }


        public ActionResult AgregarProfesion(int id)
        {
            List<DetalleProfesión> detallesProfesion = detalleProfesionBL.BuscarProfesionesPorUsuario(id);
            ViewBag.DetallesProfesion = detallesProfesion;

            Usuario usuario = usuarioBL.ObtenerPorId(id);

            ViewBag.Estados = DropDownListEstados(usuario.IdEstado);
            ViewBag.Roles = DropDownListRoles(usuario.IdRol);
            ViewBag.Departamentos = DropDownListDepartamentos(usuario.IdDepartamento);
            ViewBag.Municipios = DropDownListMunicipios(Convert.ToByte(usuario.IdMunicipio));
            ViewBag.Profesiones = DropDownListProfesiones();

            return View(usuario);
        }


        // POST: Empleado/Create
        [HttpPost]
        public ActionResult CreateDetalleProfesion(DetalleProfesión pDetalleProfesion)
        {
            try
            {
                
                    int resultado = detalleProfesionBL.Guardar(pDetalleProfesion);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro guardado.";
                        return RedirectToAction("AgregarProfesion", "Empleado", new { id = pDetalleProfesion.IdUsuario });
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            Profesion profesion = new Profesion();

            return View(pDetalleProfesion);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int id)
        {
            List<DetalleProfesión> detallesProfesion = detalleProfesionBL.BuscarProfesionesPorUsuario(id);
            ViewBag.DetallesProfesion = detallesProfesion;
            
            Usuario usuario = usuarioBL.ObtenerPorId(id);

            ViewBag.Estados = DropDownListEstados(usuario.IdEstado);
            ViewBag.Roles = DropDownListRoles(usuario.IdRol);
            ViewBag.Departamentos = DropDownListDepartamentos(usuario.IdDepartamento);
            ViewBag.Municipios = DropDownListMunicipios(Convert.ToByte(usuario.IdMunicipio));
            ViewBag.Profesiones = DropDownListProfesiones();

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(int id, Usuario pUsuario)
        {
            try
            {
                // TODO: Add insert logic here
                ModelState.Remove("Contrasena");
                ModelState.Remove("UrlImagen");

                if (ModelState.IsValid)
                {
                    // Si no se subió una nueva imagen, mantén la ruta de la imagen existente
                    if (pUsuario.UploadImage == null)
                    {
                        // Recupera la imagen existente para no perderla
                        var usuarioExistente = usuarioBL.ObtenerPorId(id);
                        pUsuario.UrlImagen = usuarioExistente.UrlImagen;
                    }
                    else
                    {
                        // Si se subió una nueva imagen, guarda la nueva ruta
                        string strDateTime = System.DateTime.Now.ToString("ddMMyyyyHHMMss");
                        string finalPath = "\\UploadedFile\\" + strDateTime + pUsuario.UploadImage.FileName;

                        pUsuario.UploadImage.SaveAs(Server.MapPath("~") + finalPath);
                        pUsuario.UrlImagen = finalPath; // Actualiza el path de la imagen
                    }

                    int resultado = usuarioBL.Modificar(pUsuario);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro actualizado.";
                        return RedirectToAction("Index");
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

            ViewBag.Estados = DropDownListEstados(pUsuario.IdEstado);
            ViewBag.Roles = DropDownListRoles(pUsuario.IdRol);
            ViewBag.Departamentos = DropDownListDepartamentos(pUsuario.IdDepartamento);
            ViewBag.Municipios = DropDownListMunicipios(Convert.ToByte(pUsuario.IdMunicipio));
            ViewBag.Profesiones = DropDownListProfesiones();

            return View(pUsuario);
        }


        [HttpPost]
        public ActionResult DeleteDetalleProfesion(int id, int idUsuario)
        {
            try
            {
                int resultado = detalleProfesionBL.Eliminar(new DetalleProfesión { IdDetalleProfesion = id });

                if (resultado > 0)
                {
                    TempData["mensaje"] = "Registro eliminado.";
                    return RedirectToAction("AgregarProfesion", "Empleado", new { id = idUsuario }); 
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

        public static List<SelectListItem> DropDownListRoles(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Rol> lista = new RolBL().Buscar(new Rol { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdRol.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdRol == pId),
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
            List<Estado> lista = new EstadoBL().Buscar(new Estado { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdEstado.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListMunicipios(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Municipio> lista = new MunicipioBL().Buscar(new Municipio { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdMunicipio.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdMunicipio == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListDepartamentos(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Departamento> lista = new DepartamentoBL().Buscar(new Departamento { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdDepartamento.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdDepartamento == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListProfesiones(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Profesion> lista = new ProfesionBL().Buscar(new Profesion { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdProfesión.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdProfesión == pId),
            }).ToList());

            return options;
        }

    }
}
