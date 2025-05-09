using System;
using System.Threading.Tasks;

namespace SGI.UI
{
    public class MenuPrincipal
    {
        private readonly MenuProductos _menuProductos;
        private readonly MenuVentas _menuVentas;
        private readonly MenuCompras _menuCompras;
        private readonly MenuCaja _menuCaja;
        private readonly MenuPlanes _menuPlanes;
        private readonly MenuTerceros _menuTerceros;
        
        public MenuPrincipal()
        {
            _menuProductos = new MenuProductos();
            _menuVentas = new MenuVentas();
            _menuCompras = new MenuCompras();
            _menuCaja = new MenuCaja();
            _menuPlanes = new MenuPlanes();
            _menuTerceros = new MenuTerceros();
        }
        
        public void MostrarMenu()
        {
            bool salir = false;
            
            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                SISTEMA DE GESTIÓN DE COMPRAS E INVENTARIO                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║            MENÚ PRINCIPAL          ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Gestión de Productos            ║");
                Console.WriteLine("║ 2. Gestión de Ventas               ║");
                Console.WriteLine("║ 3. Gestión de Compras              ║");
                Console.WriteLine("║ 4. Movimientos de Caja             ║");
                Console.WriteLine("║ 5. Gestión de Planes Promocionales ║");
                Console.WriteLine("║ 6. Gestión de Personas             ║");
                Console.WriteLine("║ 0. Salir                           ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
                {
                    case "1":
                        var menuProductos = new MenuProductos();
                        menuProductos.MostrarMenu();
                        break;
                    case "2":
                        var menuVentas = new MenuVentas();
                        menuVentas.MostrarMenu();
                        break;
                    case "3":
                        var menuCompras = new MenuCompras();
                        menuCompras.MostrarMenu();
                        break;
                    case "4":
                        var menuCaja = new MenuCaja();
                        menuCaja.MostrarMenu();
                        break;
                    case "5":
                        var menuPlanes = new MenuPlanes();
                        menuPlanes.MostrarMenu();
                        break;
                    case "6":
                        var menuTerceros = new MenuTerceros();
                        menuTerceros.MostrarMenu();
                        break;
                    case "0":
                        salir = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n╔════════════════════════════════════╗");
                        Console.WriteLine("║        ¡HASTA PRONTO!              ║");
                        Console.WriteLine("╚════════════════════════════════════╝");
                        Console.ResetColor();
                        break;
                    default:
                        MostrarMensaje("Opción no válida. Intente nuevamente.", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
            }
        }
        
        public static void MostrarEncabezado(string titulo)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            string borde = new string('=', titulo.Length + 4);
            Console.WriteLine(borde);
            Console.WriteLine($"| {titulo} |");
            Console.WriteLine(borde);
            
            Console.ResetColor();
        }
        
        public static void MostrarMensaje(string mensaje, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
        
        public static string LeerEntrada(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }
        
        public static int LeerEnteroPositivo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
                {
                    return valor;
                }
                
                MostrarMensaje("Error: Debe ingresar un número entero positivo.", ConsoleColor.Red);
            }
        }
        
        public static decimal LeerDecimalPositivo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor >= 0)
                {
                    return valor;
                }
                
                MostrarMensaje("Error: Debe ingresar un número decimal positivo.", ConsoleColor.Red);
            }
        }
        
        public static DateTime LeerFecha(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                {
                    return fecha;
                }
                
                MostrarMensaje("Error: Formato de fecha incorrecto. Use DD/MM/AAAA.", ConsoleColor.Red);
            }
        }
    }
}