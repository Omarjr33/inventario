namespace SGI.Models
{
    public class Tercero
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TipoDocumentoId { get; set; }
        public int TipoTerceroId { get; set; }
        public int CiudadId { get; set; }
        
        // Propiedades de navegación
        public string NombreCompleto => $"{Nombre} {Apellidos}";
        
        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {NombreCompleto}, Email: {Email}";
        }
    }
}