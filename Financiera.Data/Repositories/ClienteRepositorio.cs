using Financiera.Data.Infrastructure;
using Financiera.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Financiera.Data.Repositories
{
    public class ClienteRepositorio : ICliente
    {
        private readonly string cadenaConexion; 
        public ClienteRepositorio(IConfiguration config)
        {
            cadenaConexion = config["ConnectionStrings:DB"] ?? string.Empty;
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Listar()
        {
            List<Cliente> listado = new List<Cliente>();
            using var conexion = new SqlConnection(cadenaConexion);
            using var comando = new SqlCommand("ListarClientes", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            using var reader = comando.ExecuteReader();
            while (reader.Read())
                listado.Add(ConvertirReaderEnObjeto(reader));
            return listado;
        }

        public bool Modificar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Cliente ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public int Registrar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        #region . PRIVATE METHODS.

        private Cliente ConvertirReaderEnObjeto(SqlDataReader reader)
        {
            return new Cliente
            {

            };
        }


        #endregion
    }
}
