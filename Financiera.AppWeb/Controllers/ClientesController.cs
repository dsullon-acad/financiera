using Financiera.AppWeb.Models.Extensions;
using Financiera.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Financiera.AppWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly PrestamoServices services;
        public ClientesController(PrestamoServices prestamoServices)
        {
            services = prestamoServices;
        }

        public IActionResult Index()
        {
            var clientes = services.ListarClientes().Select(x => x.ToViewModel()).ToList();
            foreach (var item in clientes)
            {
                item.TipoCliente = services.ObtenerTipoClientePorID(item.TipoClienteID).Nombre;
            }
            return View(clientes);
        }

        public IActionResult Details(int id)
        {
            var cliente = services.ObtenerClientePorID(id).ToViewModel();
            cliente.TipoCliente = services.ObtenerTipoClientePorID(cliente.TipoClienteID).Nombre;
            
            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = services.ObtenerClientePorID(id).ToViewModel();            
            return View(cliente);
        }
    }
}
