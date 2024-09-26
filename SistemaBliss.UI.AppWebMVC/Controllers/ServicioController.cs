using SistemaBliss.BL;
using SistemaBliss.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBliss.UI.AppWebMVC.Controllers
{
    public class ServicioController : Controller
    {
        ServicioBL servicioBL = new ServicioBL();
        public ActionResult Index(string filtroNombre, byte? IdCategoriaServicio)
        {
            Servicio pServicio = new Servicio();

            // Filtro por nombre de servicio
            if (!string.IsNullOrEmpty(filtroNombre))
            {
                pServicio.Nombre = filtroNombre;
            }

            // Filtro por categoría de servicio
            if (IdCategoriaServicio.HasValue)
            {
                pServicio.IdCategoriaServicio = IdCategoriaServicio.Value;
            }

            // Obtener la lista filtrada de servicios
            List<Servicio> serviciosActivos = servicioBL.BuscarServiciosActivos(pServicio);
            List<Servicio> serviciosInactivos = servicioBL.BuscarServiciosInactivos(pServicio);

            // Listas de selección filtros
            ViewBag.Categorias = DropDownListCategorias();

            // Cargar estado y categoría virtual
            servicioBL.CargarEstadoVirtual(serviciosActivos);
            servicioBL.CargarCategoriaVirtual(serviciosActivos);
            servicioBL.CargarEstadoVirtual(serviciosInactivos);
            servicioBL.CargarCategoriaVirtual(serviciosInactivos);

            ViewBag.ServiciosActivos = serviciosActivos;
            ViewBag.ServiciosInactivos = serviciosInactivos;

            return View();
        }





        // GET: Servicio/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = DropDownListCategorias();
            ViewBag.Estados = DropDownListEstados();
            return View();
        }

        // POST: Servicio/Create
        [HttpPost]
        public ActionResult Create(Servicio pServicio)
        {
            try
            {
                if (pServicio.UploadImage != null && pServicio.UploadImage.ContentLength > 0)
                {
                    // Generar la ruta para la imagen
                    string strDateTime = System.DateTime.Now.ToString("ddMMyyyyHHMMss");
                    string finalPath = "\\UploadedFile\\" + strDateTime + pServicio.UploadImage.FileName;

                    // Guardar la imagen en el servidor
                    pServicio.UploadImage.SaveAs(Server.MapPath("~") + finalPath);
                    pServicio.Imagen = finalPath; // Guardar la ruta de la imagen
                }
                else
                {
                    // Si no se subió ninguna imagen, puedes dejar la propiedad Imagen vacía o asignar un valor por defecto
                    pServicio.Imagen = null; // O una imagen por defecto, como "\\UploadedFile\\default.jpg";
                }

                if (ModelState.IsValid)
                {

                    int resultado = servicioBL.Guardar(pServicio);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Servicio guardado.";
                        return RedirectToAction("Index");
                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un servicio con el mismo nombre.");
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
            ViewBag.Categorias = DropDownListCategorias();
            ViewBag.Estados = DropDownListEstados();
            return View();
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(byte id)
        {
            Servicio servicio = servicioBL.ObtenerPorId(id);
            // Cargar lista de seleccion
            ViewBag.Categorias = DropDownListCategorias();
            ViewBag.Estados = DropDownListEstados();
            return View(servicio);
        }


        // POST: Servicio/Edit/5
        [HttpPost]
        public ActionResult Edit(byte id, Servicio pServicio)
        {
            try
            {
                ModelState.Remove("UrlImagen");

                if (ModelState.IsValid)
                {
                    // Si no se subió una nueva imagen, mantén la ruta de la imagen existente
                    if (pServicio.UploadImage == null)
                    {
                        // Recupera la imagen existente para no perderla
                        var usuarioExistente = servicioBL.ObtenerPorId(id);
                        pServicio.Imagen = usuarioExistente.Imagen;
                    }
                    else
                    {
                        // Si se subió una nueva imagen, guarda la nueva ruta
                        string strDateTime = System.DateTime.Now.ToString("ddMMyyyyHHMMss");
                        string finalPath = "\\UploadedFile\\" + strDateTime + pServicio.UploadImage.FileName;

                        pServicio.UploadImage.SaveAs(Server.MapPath("~") + finalPath);
                        pServicio.Imagen = finalPath; // Actualiza el path de la imagen
                    }

                    int resultado = servicioBL.Modificar(pServicio);

                    if (resultado > 0)
                    {
                        TempData["mensaje"] = "Registro actualizado.";
                        return RedirectToAction("Index");
                    }
                    else if (resultado == -1)
                    {
                        ModelState.AddModelError("", "Ya existe un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al registrar servicio, intente de nuevo o contacte al soporte.");
                    }

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            // Cargar lista de seleccion
            ViewBag.Categorias = DropDownListCategorias();
            ViewBag.Estados = DropDownListEstados();
            return View();
        }

        public static List<SelectListItem> DropDownListCategorias(byte pId = 0)
        {
            List<SelectListItem> options = new List<SelectListItem>
                {
                  new SelectListItem { Value = null, Text = "Seleccionar" }
                };

            // Buscar registros en la DB
            List<CategoriaServicio> lista = new CategoriaServicioBL().Buscar(new CategoriaServicio { });

            // Agregar opciones
            options.AddRange(lista.OrderBy(x => x.Nombre).Select(x => new SelectListItem
            {
                Value = x.IdCategoriaServicio.ToString(), // PK
                Text = x.Nombre,
                Selected = (x.IdCategoriaServicio == pId),
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
    }
}
