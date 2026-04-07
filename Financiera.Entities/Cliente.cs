namespace Financiera.Entities
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Apellidos { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TipoClienteID { get; set; }
        public bool Activo { get; set; }

        public string NombreCompleto { 
            get {
                return $"{Apellidos}, {Nombres}";
            } 
        }
    }
}
