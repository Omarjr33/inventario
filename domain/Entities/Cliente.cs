namespace SGI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string TerceroId { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaCompra { get; set; }
        
        // Propiedades de navegación
        public Tercero? Tercero { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id}, TerceroID: {TerceroId}, Última compra: {FechaCompra?.ToString("d") ?? "Sin compras"}";
        }
    }
}