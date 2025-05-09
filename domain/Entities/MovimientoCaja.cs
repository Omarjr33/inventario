namespace SGI.Models
{
    public class MovimientoCaja
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoMovimientoId { get; set; }
        public decimal Valor { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public string TerceroId { get; set; } = string.Empty;
        
        // Propiedades de navegación
        public string? TipoMovimientoNombre { get; set; }
        public string? TipoMovimiento { get; set; } // Entrada o Salida
        public Tercero? Tercero { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id}, Fecha: {Fecha:d}, Tipo: {TipoMovimientoNombre} ({TipoMovimiento}), Valor: {Valor:C}";
        }
    }
}