using Financiera.Entities;

namespace Financiera.Data.Infrastructure
{
    public interface ICuotaPrestamo
    {
        List<CuotaPrestamo> Listar(int prestamoID);
        bool Modificar(CuotaPrestamo cuota);
    }
}
