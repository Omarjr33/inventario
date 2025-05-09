namespace SGI.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string TerceroProveedorId { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string TerceroEmpleadoId { get; set; } = string.Empty;
        public string DocCompra { get; set; } = string.Empty;
        
        // Propiedades de navegación
        public Tercero? Proveedor { get; set; }
        public Tercero? Empleado { get; set; }
        public List<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
        
        public decimal Total => Detalles.Sum(d => d.Valor * d.Cantidad);
        
        public override string ToString()
        {
            return $"ID: {Id}, Fecha: {Fecha:d}, Doc: {DocCompra}, Total: {Total:C}";
        }
    }
}