using System;

namespace SGI.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string TerceroId { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public string Cargo { get; set; } = string.Empty;
        public int EpsId { get; set; }
        public int ArlId { get; set; }
        
        // Propiedades de navegación
        public Tercero? Tercero { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id}, TerceroID: {TerceroId}, Cargo: {Cargo}, Salario: {Salario:C}";
        }
    }
}