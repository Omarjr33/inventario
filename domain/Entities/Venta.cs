namespace SGI.Models
{
    public class Venta
    {
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public string TerceroEmpleadoId { get; set; } = string.Empty;
        public string TerceroClienteId { get; set; } = string.Empty;
        
        // Propiedades de navegación
        public Tercero? Empleado { get; set; }
        public Tercero? Cliente { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
        
        public decimal Total => Detalles.Sum(d => d.Valor * d.Cantidad);
        
        public override string ToString()
        {
            return $"Factura: {FacturaId}, Fecha: {Fecha:d}, Total: {Total:C}";
        }
    }
}