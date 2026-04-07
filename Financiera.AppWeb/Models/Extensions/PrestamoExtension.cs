using Financiera.Entities;

namespace Financiera.AppWeb.Models.Extensions
{
    public static class PrestamoExtension
    {
        public static PrestamoVM ToViewModel(this Prestamo prestamo)
        {
            return new PrestamoVM
            {
                ID = prestamo.ID,
                Fecha = prestamo.Fecha,
                FechaDesposito = prestamo.FechaDeposito,
                Importe = prestamo.Importe,
                Moneda = prestamo.Moneda,
                ClienteID = prestamo.ClienteID,
            };
        }

        public static Prestamo ToEntity(this PrestamoVM prestamoVM)
        {
            return new Prestamo
            {
                ID = prestamoVM.ID,
                Fecha = prestamoVM.Fecha,
                ClienteID = prestamoVM.ClienteID,
                FechaDeposito = prestamoVM.FechaDesposito,
                Importe = prestamoVM.Importe,
                Moneda = prestamoVM.Moneda,
                Plazo = prestamoVM.Plazo,
                Tasa = prestamoVM.Tasa,
                TipoPrestamoID = prestamoVM.TipoPrestamoID,
            };
        }
    }
}
