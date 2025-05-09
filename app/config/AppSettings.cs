namespace SGI.Config
{
    public static class AppSettings
    {
        public static string ConnectionString = "Server=localhost;Database=sgi_campus;Uid=root;Pwd=;";
        
        // Configuraciones adicionales de la aplicación
        public static int NumeroPaginacion = 10;
        public static bool MostrarRegistrosEliminados = false;
        public static int TiempoEsperaConsultas = 30; // segundos
    }
}