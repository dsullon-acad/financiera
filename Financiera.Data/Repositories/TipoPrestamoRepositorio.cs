using Financiera.Data.Infrastructure;
using Financiera.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Financiera.Data.Repositories
{
    public class TipoPrestamoRepositorio : ITipoPrestamo
    {
        private readonly string cadenaConexion;
        public TipoPrestamoRepositorio(IConfiguration config)
        {
            cadenaConexion = config["ConnectionStrings:DB"] ?? string.Empty;
        }
        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoPrestamo> Listar()
        {
            List<TipoPrestamo> listado = new List<TipoPrestamo>();
            using var conexion = new SqlConnection(cadenaConexion);
            using var comando = new SqlCommand("ListarTipoPrestamo", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            using var reader = comando.ExecuteReader();
            while (reader.Read()) {
                listado.Add(ConvertirReaderEnObjeto(reader));
            }
            return listado;
        }

        public TipoPrestamo ObtenerPorId(int id)
        {
            TipoPrestamo tipo = null;
            using var conexion = new SqlConnection(cadenaConexion);
            using var comando = new SqlCommand("ObtenerTipoPrestamoPorID", conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            using var reader = comando.ExecuteReader();
            reader.Read();
            tipo = ConvertirReaderEnObjeto(reader);
            return tipo;
        }

        public bool Modificar(TipoPrestamo entity)
        {
            throw new NotImplementedException();
        }

       

        public int Registrar(TipoPrestamo entity)
        {
            throw new NotImplementedException();
        }


        #region . PRIVATE METHODS .

        private TipoPrestamo ConvertirReaderEnObjeto(SqlDataReader reader)
        {
            return new TipoPrestamo
            {
                ID = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Tasa = reader.GetDecimal(2)
            };
        }

        #endregion
    }
}
