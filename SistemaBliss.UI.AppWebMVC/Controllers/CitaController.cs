using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaBliss.EN;
using SistemaBliss.BL;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class CitaController : Controller
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


        public ActionResult IndexDetalle(int Id)
        {

            List<DetalleCita> detallesCita = detallecitaBL.BuscarPorCita(Id);

            ViewBag.DetallesCita = detallesCita;

            // Devolver la vista
            return View();
        }


        public ActionResult Create()
        {
            ViewBag.Clientes = DropDownListCliente();
            ViewBag.Estados = DropDownListEstados();
            ViewBag.Servicios = ListaServicios();
            ViewBag.Empleados = ListaEmpleados();
            ViewBag.EstadosCita = ListaEstado();
            ViewBag.EstadosDetalleCita = DropDownListEstadosDetalleCita();

            return View(new Cita());

        }

        // POST: Empleado/Create
        //[HttpPost]
        //public ActionResult Create(Cita pCita)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            int resultado = citaBL.Guardar(pCita);

        //            if (resultado > 0)
        //            {
        //                TempData["mensaje"] = "Registro guardado.";
        //                return RedirectToAction("Index");
        //            }
        //            else if (resultado == -1)
        //            {
        //                ModelState.AddModelError("", "Ya existe un registro con el mismo teléfono.");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Error al registrar, intente de nuevo o contacte al soporte.");
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }


        //    // Cargar lista de seleccion
        //    ViewBag.Clientes = DropDownListCliente(pCita.IdUsuario);
        //    ViewBag.Estados = DropDownListEstados(pCita.IdEstado);

        //    return View(pCita);
        //}

        [HttpPost]
        public ActionResult Create(Cita pCita)
        {
            try
            {
                // TODO: Add insert logic here
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
                        ModelState.AddModelError("", "Ya existe un registro con el mismo correlativo.");
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
            // Listas de seleccion filtros
            ViewBag.Clientes = DropDownListCliente();
            ViewBag.Estados = DropDownListEstados();
            ViewBag.Servicios = ListaServicios();
            ViewBag.Empleados = ListaEmpleados();
            ViewBag.EstadosCita = ListaEstado();
            ViewBag.EstadosDetalleCita = DropDownListEstadosDetalleCita();


            return View(pCita);
        }

        [HttpPost]
        public ActionResult CreateDetalleCita(DetalleCita pDetalleCita)
        {
            try
            {
                    int resultado = detallecitaBL.Guardar(pDetalleCita);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro guardado.";
                        return RedirectToAction("Edit", "Cita", new { id = pDetalleCita.IdCita }); // Asumiendo que tienes IdCita en pDetalleCita

                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un registro con el mismo correlativo.");
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
            // Listas de seleccion filtros
            ViewBag.Clientes = DropDownListCliente();
            ViewBag.Estados = DropDownListEstados();
            ViewBag.Servicios = ListaServicios();
            ViewBag.Empleados = ListaEmpleados();
            ViewBag.EstadosCita = ListaEstado();
            ViewBag.EstadosDetalleCita = DropDownListEstadosDetalleCita();


            return View(pDetalleCita);
        }




        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
        {
            List<DetalleCita> detallesCita = detallecitaBL.BuscarPorCita(id);
            ViewBag.DetallesCita = detallesCita;

            decimal totalPrecio = detallecitaBL.BuscarTotalPorCita(id);
            ViewBag.TotalPrecio = totalPrecio;

            TimeSpan tiempoEstimado = detallecitaBL.BuscarTiempoTotalPorCita(id);
            ViewBag.TiempoEstimado = $"{tiempoEstimado.Hours:D2}:{tiempoEstimado.Minutes:D2}";

            Cita cita = citaBL.ObtenerPorId(id);

            ViewBag.Clientes = DropDownListCliente(cita.IdUsuario);
            ViewBag.Estados = DropDownListEstados(cita.IdEstado);
            ViewBag.Servicios = ListaServicios();
            ViewBag.Empleados = ListaEmpleados();
            ViewBag.EstadosCita = ListaEstado();
            ViewBag.EstadosDetalleCita = DropDownListEstadosDetalleCita();

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


        [HttpPost]
        public ActionResult DeleteDetalleCita(byte id, int idCita)
        {
            try
            {
                int resultado = detallecitaBL.Eliminar(new DetalleCita { IdDetalleCita = id });

                if (resultado > 0)
                {
                    TempData["mensaje"] = "Registro eliminado.";
                    return RedirectToAction("Edit", "Cita", new { id = idCita });
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

        public List<Servicio> ListaServicios(byte pIdServicio = 0)
        {
            List<Servicio> lista = new List<Servicio>();
            lista = new ServicioBL().BuscarServiciosCita(new Servicio { IdServicio = pIdServicio });
            lista = lista.OrderBy(x => x.Nombre).ToList();
            return lista;
        }

        public List<Usuario> ListaEmpleados(byte pIdServicio = 0)
        {
            List<Usuario> lista = new List<Usuario>();
            lista = new UsuarioBL().BuscarEmpleadosCita(new Usuario { IdUsuario = pIdServicio });
            lista = lista.OrderBy(x => x.Nombre).ToList();
            return lista;
        }

        public List<Estado> ListaEstado(byte pIdEstado = 0)
        {
            List<Estado> lista = new List<Estado>();
            lista = new EstadoBL().BuscarEstadosDetallesCitas(new Estado { IdEstado = pIdEstado });
            lista = lista.OrderBy(x => x.Nombre).ToList();
            return lista;
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
