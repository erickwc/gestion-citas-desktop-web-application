using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class CitaControllerfake : Controller
    {
        CitaBL citaBL = new CitaBL();
        DetalleCitaBL detallecitaBL = new DetalleCitaBL();
        // GET: Cita
        public ActionResult Index(DateTime? fechaInicioPendientes = null, DateTime? fechaFinPendientes = null)
        {
            Cita pCita = new Cita();

            List<Cita> citasPendientes = citaBL.BuscarCitasPendientes(pCita, fechaInicioPendientes, fechaFinPendientes);
            List<Cita> citasConfirmadas = citaBL.BuscarCitasConfirmadas(pCita, fechaInicioPendientes, fechaFinPendientes);
            List<Cita> citasFinalizadas = citaBL.BuscarCitasFinalizadas(pCita, fechaInicioPendientes, fechaFinPendientes);

            // Pasar las listas a la vista a través de ViewBag
            ViewBag.CitasPendientes = citasPendientes;
            ViewBag.CitasConfirmadas = citasConfirmadas;
            ViewBag.CitasFinalizadas = citasFinalizadas;

            return View();
        }


        public ActionResult Create()
        {
            ViewBag.Clientes = DropDownListCliente();
            ViewBag.Estados = DropDownListEstados();
            ViewBag.Servicios = DropDownListServicios();
            ViewBag.EstadosDetalleCita = DropDownListEstadosDetalleCita();
            ViewBag.Empleados = DropDownListEmpleados(); 

            return View();

        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(Cita pCita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = citaBL.Guardar(pCita);

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


            // Cargar lista de seleccion
            ViewBag.Clientes = DropDownListCliente(pCita.IdUsuario);
            ViewBag.Estados = DropDownListEstados(pCita.IdEstado);

            return View(pCita);
        }


        // POST: Empleado/Create
        [HttpPost]
        public ActionResult CreateDetalleCita(DetalleCita pCita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = detallecitaBL.Guardar(pCita);

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


            // Cargar lista de seleccion
            ViewBag.Clientes = DropDownListCliente(pCita.IdUsuario);
            ViewBag.Estados = DropDownListEstados(pCita.IdEstado);

            return View(pCita);
        }


        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
        {
            Cita cita = citaBL.ObtenerPorId(id);

            ViewBag.Clientes = DropDownListCliente(cita.IdUsuario);
            ViewBag.Estados = DropDownListEstados(cita.IdEstado);
            return View(cita);
        }

        // POST: Cita/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cita pCita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int resultado = citaBL.Modificar(pCita);

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


            // Cargar lista de seleccion
            ViewBag.Clientes = DropDownListCliente(pCita.IdUsuario);
            ViewBag.Estados = DropDownListEstados(pCita.IdEstado);

            return View(pCita);
        }

        public static List<SelectListItem> DropDownListCliente(int pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Cita> lista = new CitaBL().BuscarClientes(new Cita { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Cliente).Select(x => new SelectListItem
            {
                Value = x.IdUsuario.ToString(), // PK
                Text = x.Cliente,
                Selected = (x.IdUsuario == pId),
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
            List<Estado> lista = new EstadoBL().BuscarEstadosCitas(new Estado { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdEstado.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListServicios(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Servicio> lista = new ServicioBL().BuscarServiciosCita(new Servicio { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdServicio.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListEmpleados(int pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Usuario> lista = new UsuarioBL().BuscarEmpleadosCita(new Usuario { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdUsuario.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }

        public static List<SelectListItem> DropDownListEstadosDetalleCita(int pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                        new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<Estado> lista = new EstadoBL().BuscarEstadosDetallesCitas(new Estado { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdEstado.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdEstado == pId),
            }).ToList());

            return options;
        }

    }
}
