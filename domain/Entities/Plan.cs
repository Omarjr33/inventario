namespace SGI.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Descuento { get; set; }
        
        // Lista de productos en el plan promocional
        public List<Producto> Productos { get; set; } = new List<Producto>();

        public bool EstaVigente()
        {
            DateTime hoy = DateTime.Today;
            return hoy >= FechaInicio && hoy <= FechaFin;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Descuento: {Descuento:P}, Vigencia: {FechaInicio:d} - {FechaFin:d}";
        }
    }
}