using Financiera.AppWeb.Models;
using Financiera.BusinessLogic;
using Financiera.Entities;
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
            var clientes = services.ListarClientes().Select(x => new ClienteVM
            {
                ID = x.ID,
                Nombres = $"{x.Apellidos}, {x.Nombres}",
                Direccion = x.Direccion,
                Email = x.Email,
                Telefono = x.Telefono,
                TipoClienteID = x.TipoClienteID
            }).ToList();
            foreach (var item in clientes)
            {
                item.TipoCliente = services.ObtenerTipoClientePorID(item.TipoClienteID).Nombre;
            }
            return View(clientes);
        }
    }
}
