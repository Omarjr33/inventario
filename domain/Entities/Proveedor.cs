namespace SGI.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string TerceroId { get; set; } = string.Empty;
        public double Descuento { get; set; }
        public int DiaPago { get; set; }
        
        // Propiedades de navegación
        public Tercero? Tercero { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id}, TerceroID: {TerceroId}, Descuento: {Descuento:P}, Día pago: {DiaPago}";
        }
    }
}