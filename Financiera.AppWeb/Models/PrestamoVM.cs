namespace Financiera.AppWeb.Models
{
    public class PrestamoVM
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDesposito { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public Decimal Importe { get; set; }
        public string Moneda { get; set; } = string.Empty;
    }
}
