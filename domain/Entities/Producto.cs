namespace SGI.Models
{
    public class Producto
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string CodigoBarra { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Stock: {Stock}, Código: {CodigoBarra}";
        }
    }
}