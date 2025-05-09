namespace SGI.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string ProductoId { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Valor { get; set; }
        
        // Propiedades de navegación
        public Producto? Producto { get; set; }
        
        public decimal Subtotal => Valor * Cantidad;
        
        public override string ToString()
        {
            return $"ID: {Id}, Producto: {ProductoId}, Cantidad: {Cantidad}, Valor: {Valor:C}, Subtotal: {Subtotal:C}";
        }
    }
}