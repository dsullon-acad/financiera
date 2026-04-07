using Financiera.Data.Infrastructure;
using Financiera.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financiera.BusinessLogic
{
    public class PrestamoServices
    {
        private readonly ICliente clienteDB;
        private readonly ITipoCliente tipoClienteDB;
        private readonly IPrestamo prestamoDB;
        public PrestamoServices(ICliente cliente, ITipoCliente tipoCliente, IPrestamo prestamo) { 
            clienteDB = cliente;
            tipoClienteDB = tipoCliente;
            prestamoDB = prestamo;
        }

        public List<Cliente> ListarClientes()
        {
            return clienteDB.Listar();
        }

        public Cliente ObtenerClientePorID(int id)
        {
            return clienteDB.ObtenerPorId(id);
        }

        public TipoCliente ObtenerTipoClientePorID(int id)
        {
            return tipoClienteDB.ObtenerPorId(id);
        }

        public List<Prestamo> ListarPrestamos()
        {
            return prestamoDB.Listar();
        }

        public Prestamo CrearPrestamo(Prestamo nuevoPrestamo)
        {
            int nuevoID = prestamoDB.Registrar(nuevoPrestamo);
            return prestamoDB.ObtenerPorId(nuevoID);
        }
    }
}
