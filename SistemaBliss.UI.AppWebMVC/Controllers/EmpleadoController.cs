using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaBliss.BL;
using SistemaBliss.EN;
using System.Security.Cryptography.X509Certificates;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        UsuarioBL usuarioBL = new UsuarioBL();
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
            return View();

        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(Usuario pUsuario)
        {
            try
            {
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

        // GET: Empleado/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = usuarioBL.ObtenerPorId(id);

            // Cargar lista de seleccion
            ViewBag.Estados = DropDownListEstados(usuario.IdEstado);
            ViewBag.Roles = DropDownListRoles(usuario.IdRol);
            ViewBag.Departamentos = DropDownListDepartamentos(usuario.IdDepartamento);
            ViewBag.Municipios = DropDownListMunicipios(Convert.ToByte(usuario.IdMunicipio));

            return View(usuario);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario pUsuario)
        {
            try
            {
                // TODO: Add insert logic here
                ModelState.Remove("Contrasena");

                if (ModelState.IsValid)
                {
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

            return View(pUsuario);
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
