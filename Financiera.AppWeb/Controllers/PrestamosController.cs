using Financiera.AppWeb.Models;
using Financiera.AppWeb.Models.Extensions;
using Financiera.BusinessLogic;
using Financiera.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Financiera.AppWeb.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly PrestamoServices service;
        public PrestamosController(PrestamoServices prestamoServices)
        {
            service = prestamoServices;
        }

        public IActionResult Index()
        {
            var listado = service.ListarPrestamos().Select(prestamo => prestamo.ToViewModel());
            return View(listado);
        }

        public IActionResult Create()
        {
            var listadoClientes = service.ListarClientes();
            var listadoTipos = service.ListarTiposPrestamo();
            ViewBag.clientes = new SelectList(listadoClientes, "ID", "NombreCompleto");
            ViewBag.tipos = new SelectList(listadoTipos, "ID", "Nombre");
            return View(new PrestamoVM());
        }

        [HttpPost]
        public IActionResult Create(PrestamoVM nuevoPrestamo)
        {
            Prestamo prestamo = service.CrearPrestamo(nuevoPrestamo.ToEntity());
            return RedirectToAction("Details", new { id = prestamo.ID });
        }

        public IActionResult Details(int id)
        {
            var prestamo = service.ObtenerPrestamoPorID(id).ToViewModel();
            return View(prestamo);
        }
    }
}
