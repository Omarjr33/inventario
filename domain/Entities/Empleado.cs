namespace SGI.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string TerceroId { get; set; } = string.Empty;
        public DateTime FechaIngreso { get; set; }
        public double SalarioBase { get; set; }
        public int EpsId { get; set; }
        public int ArlId { get; set; }
        
        // Propiedades de navegación
        public Tercero? Tercero { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id}, TerceroID: {TerceroId}, Fecha ingreso: {FechaIngreso:d}, Salario: {SalarioBase:C}";
        }
    }
}