using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGI.Models;
using SGI.Repositories;

namespace SGI.UI
{
    public class MenuPlanes
    {
        private readonly PlanRepository _planRepository;
        private readonly ProductoRepository _productoRepository;
        
        public MenuPlanes()
        {
            _planRepository = new PlanRepository();
            _productoRepository = new ProductoRepository();
        }
        
        public void MostrarMenu()
        {
            bool regresar = false;
            
            while (!regresar)
            {
                Console.Clear();
                MenuPrincipal.MostrarEncabezado("GESTIÓN DE PLANES PROMOCIONALES");
                
                Console.WriteLine("\nOPCIONES:");
                Console.WriteLine("1. Listar Planes");
                Console.WriteLine("2. Ver Detalle de Plan");
                Console.WriteLine("3. Crear Nuevo Plan");
                Console.WriteLine("4. Modificar Plan");
                Console.WriteLine("5. Eliminar Plan");
                Console.WriteLine("6. Ver Planes Vigentes");
                Console.WriteLine("0. Regresar al Menú Principal");
                
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
                {
                    case "1":
                        ListarPlanes().Wait();
                        break;
                    case "2":
                        VerDetallePlan().Wait();
                        break;
                    case "3":
                        CrearPlan().Wait();
                        break;
                    case "4":
                        ModificarPlan().Wait();
                        break;
                    case "5":
                        EliminarPlan().Wait();
                        break;
                    case "6":
                        VerPlanesVigentes().Wait();
                        break;
                    case "0":
                        regresar = true;
                        break;
                    default:
                        MenuPrincipal.MostrarMensaje("Opción no válida. Intente nuevamente.", ConsoleColor.Yellow);
                        Console.ReadKey();
                        break;
                }
            }
        }
        
        private async Task ListarPlanes()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("LISTA DE PLANES PROMOCIONALES");
            
            try
            {
                var planes = await _planRepository.GetAllAsync();
                
                if (!planes.Any())
                {
                    MenuPrincipal.MostrarMensaje("\nNo hay planes registrados.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.WriteLine("\n{0,-5} {1,-20} {2,-12} {3,-12} {4,-15} {5,-10}", 
                        "ID", "Nombre", "Inicio", "Fin", "Descuento", "Estado");
                    Console.WriteLine(new string('-', 80));
                    
                    foreach (var plan in planes)
                    {
                        bool vigente = plan.EstaVigente();
                        ConsoleColor color = vigente ? ConsoleColor.Green : ConsoleColor.Gray;
                        
                        Console.ForegroundColor = color;
                        Console.WriteLine("{0,-5} {1,-20} {2,-12} {3,-12} {4,-15} {5,-10}", 
                            plan.Id, 
                            plan.Nombre.Length > 17 ? plan.Nombre.Substring(0, 17) + "..." : plan.Nombre,
                            plan.FechaInicio.ToString("dd/MM/yyyy"),
                            plan.FechaFin.ToString("dd/MM/yyyy"),
                            plan.Descuento.ToString("P"),
                            vigente ? "VIGENTE" : "INACTIVO");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al listar planes: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task VerDetallePlan()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("DETALLE DE PLAN PROMOCIONAL");
            
            try
            {
                int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del plan: ");
                
                var plan = await _planRepository.GetByIdAsync(id);
                
                if (plan == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl plan no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    bool vigente = plan.EstaVigente();
                    
                    Console.WriteLine("\nINFORMACIÓN DEL PLAN:");
                    Console.WriteLine($"ID: {plan.Id}");
                    Console.WriteLine($"Nombre: {plan.Nombre}");
                    Console.WriteLine($"Fecha Inicio: {plan.FechaInicio:dd/MM/yyyy}");
                    Console.WriteLine($"Fecha Fin: {plan.FechaFin:dd/MM/yyyy}");
                    Console.WriteLine($"Descuento: {plan.Descuento:P}");
                    Console.WriteLine($"Estado: {(vigente ? "VIGENTE" : "INACTIVO")}");
                    
                    Console.WriteLine("\nPRODUCTOS EN PROMOCIÓN:");
                    
                    if (!plan.Productos.Any())
                    {
                        MenuPrincipal.MostrarMensaje("  No hay productos asignados a este plan.", ConsoleColor.Yellow);
                    }
                    else
                    {
                        Console.WriteLine("{0,-10} {1,-30} {2,-10}", 
                            "ID", "Nombre", "Stock");
                        Console.WriteLine(new string('-', 60));
                        
                        foreach (var producto in plan.Productos)
                        {
                            Console.WriteLine("{0,-10} {1,-30} {2,-10}", 
                                producto.Id, 
                                producto.Nombre.Length > 27 ? producto.Nombre.Substring(0, 27) + "..." : producto.Nombre,
                                producto.Stock);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al obtener detalle del plan: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task CrearPlan()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("CREAR NUEVO PLAN PROMOCIONAL");
            
            try
            {
                string nombre = MenuPrincipal.LeerEntrada("\nNombre del plan: ");
                DateTime fechaInicio = MenuPrincipal.LeerFecha("Fecha de inicio (DD/MM/AAAA): ");
                DateTime fechaFin = MenuPrincipal.LeerFecha("Fecha de fin (DD/MM/AAAA): ");
                
                // Validar que la fecha de fin sea posterior a la de inicio
                if (fechaFin < fechaInicio)
                {
                    MenuPrincipal.MostrarMensaje("\nError: La fecha de fin debe ser posterior a la fecha de inicio.", ConsoleColor.Red);
                    Console.ReadKey();
                    return;
                }
                
                decimal descuento = 0;
                while (true)
                {
                    Console.Write("Porcentaje de descuento (0-100): ");
                    if (decimal.TryParse(Console.ReadLine(), out descuento) && descuento >= 0 && descuento <= 100)
                    {
                        // Convertir de porcentaje a decimal (ej: 10% -> 0.1)
                        descuento = descuento / 100;
                        break;
                    }
                    
                    MenuPrincipal.MostrarMensaje("Error: Debe ingresar un número entre 0 y 100.", ConsoleColor.Red);
                }
                
                var plan = new Plan
                {
                    Nombre = nombre,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Descuento = descuento,
                    Productos = new List<Producto>()
                };
                
                // Agregar productos al plan
                await AgregarProductosAlPlan(plan);
                
                // Si no se agregaron productos, confirmar si se desea guardar el plan
                if (!plan.Productos.Any())
                {
                    string confirmar = MenuPrincipal.LeerEntrada("\nNo se agregaron productos al plan. ¿Desea guardarlo de todas formas? (S/N): ");
                    
                    if (confirmar.ToUpper() != "S")
                    {
                        MenuPrincipal.MostrarMensaje("\nOperación cancelada.", ConsoleColor.Yellow);
                        Console.ReadKey();
                        return;
                    }
                }
                
                bool resultado = await _planRepository.InsertAsync(plan);
                
                if (resultado)
                {
                    MenuPrincipal.MostrarMensaje("\nPlan promocional creado correctamente.", ConsoleColor.Green);
                }
                else
                {
                    MenuPrincipal.MostrarMensaje("\nNo se pudo crear el plan promocional.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al crear el plan: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task ModificarPlan()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("MODIFICAR PLAN PROMOCIONAL");
            
            try
            {
                int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del plan a modificar: ");
                
                var plan = await _planRepository.GetByIdAsync(id);
                
                if (plan == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl plan no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    bool regresar = false;
                    while (!regresar)
                    {
                        Console.Clear();
                        MenuPrincipal.MostrarEncabezado("MODIFICAR PLAN PROMOCIONAL");
                        Console.WriteLine($"\nPlan actual: {plan.Nombre}");
                        Console.WriteLine("\n¿Qué desea modificar?");
                        Console.WriteLine("1. Nombre del plan");
                        Console.WriteLine("2. Fecha de inicio");
                        Console.WriteLine("3. Fecha de fin");
                        Console.WriteLine("4. Porcentaje de descuento");
                        Console.WriteLine("5. Productos del plan");
                        Console.WriteLine("0. Regresar");
                        
                        Console.Write("\nSeleccione una opción: ");
                        string opcion = Console.ReadLine() ?? "";
                        
                        switch (opcion)
                        {
                            case "1":
                                string nombre = MenuPrincipal.LeerEntrada($"Ingrese el nuevo nombre ({plan.Nombre}): ");
                                if (!string.IsNullOrWhiteSpace(nombre))
                                {
                                    plan.Nombre = nombre;
                                }
                                break;
                                
                            case "2":
                                DateTime fechaInicio = MenuPrincipal.LeerFecha($"Ingrese la nueva fecha de inicio ({plan.FechaInicio:d}): ");
                                if (fechaInicio > plan.FechaFin)
                                {
                                    MenuPrincipal.MostrarMensaje("\nError: La fecha de inicio debe ser anterior a la fecha de fin.", ConsoleColor.Red);
                                    Console.ReadKey();
                                    continue;
                                }
                                plan.FechaInicio = fechaInicio;
                                break;
                                
                            case "3":
                                DateTime fechaFin = MenuPrincipal.LeerFecha($"Ingrese la nueva fecha de fin ({plan.FechaFin:d}): ");
                                if (fechaFin < plan.FechaInicio)
                                {
                                    MenuPrincipal.MostrarMensaje("\nError: La fecha de fin debe ser posterior a la fecha de inicio.", ConsoleColor.Red);
                                    Console.ReadKey();
                                    continue;
                                }
                                plan.FechaFin = fechaFin;
                                break;
                                
                            case "4":
                                decimal descuento = 0;
                                while (true)
                                {
                                    Console.Write($"Ingrese el nuevo porcentaje de descuento ({plan.Descuento:P}): ");
                                    if (decimal.TryParse(Console.ReadLine(), out descuento) && descuento >= 0 && descuento <= 100)
                                    {
                                        plan.Descuento = descuento / 100;
                                        break;
                                    }
                                    MenuPrincipal.MostrarMensaje("\nError: El descuento debe estar entre 0 y 100.", ConsoleColor.Red);
                                }
                                break;
                                
                            case "5":
                                await AgregarProductosAlPlan(plan);
                                break;
                                
                            case "0":
                                regresar = true;
                                continue;
                                
                            default:
                                MenuPrincipal.MostrarMensaje("\nOpción no válida. Intente nuevamente.", ConsoleColor.Yellow);
                                Console.ReadKey();
                                continue;
                        }
                        
                        bool resultado = await _planRepository.UpdateAsync(plan);
                        
                        if (resultado)
                        {
                            MenuPrincipal.MostrarMensaje("\nPlan actualizado correctamente.", ConsoleColor.Green);
                        }
                        else
                        {
                            MenuPrincipal.MostrarMensaje("\nNo se pudo actualizar el plan.", ConsoleColor.Red);
                        }
                        
                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al modificar el plan: {ex.Message}", ConsoleColor.Red);
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        
        private async Task EliminarPlan()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("ELIMINAR PLAN PROMOCIONAL");
            
            try
            {
                int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del plan a eliminar: ");
                
                var plan = await _planRepository.GetByIdAsync(id);
                
                if (plan == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl plan no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.WriteLine($"\nPlan a eliminar: {plan.Nombre}");
                    Console.WriteLine($"Vigencia: {plan.FechaInicio:dd/MM/yyyy} - {plan.FechaFin:dd/MM/yyyy}");
                    Console.WriteLine($"Descuento: {plan.Descuento:P}");
                    Console.WriteLine($"Productos en promoción: {plan.Productos.Count}");
                    
                    string confirmacion = MenuPrincipal.LeerEntrada("\n¿Está seguro de eliminar este plan promocional? (S/N): ");
                    
                    if (confirmacion.ToUpper() == "S")
                    {
                        bool resultado = await _planRepository.DeleteAsync(id);
                        
                        if (resultado)
                        {
                            MenuPrincipal.MostrarMensaje("\nPlan promocional eliminado correctamente.", ConsoleColor.Green);
                        }
                        else
                        {
                            MenuPrincipal.MostrarMensaje("\nNo se pudo eliminar el plan promocional.", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MenuPrincipal.MostrarMensaje("\nOperación cancelada.", ConsoleColor.Yellow);
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al eliminar el plan: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task VerPlanesVigentes()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("PLANES PROMOCIONALES VIGENTES");
            
            try
            {
                var planes = await _planRepository.GetPlanesVigentesAsync();
                
                if (!planes.Any())
                {
                    MenuPrincipal.MostrarMensaje("\nNo hay planes promocionales vigentes actualmente.", ConsoleColor.Yellow);
                }
                else
                {
                    MenuPrincipal.MostrarMensaje($"\nSe encontraron {planes.Count()} planes promocionales vigentes.", ConsoleColor.Green);
                    
                    Console.WriteLine("\n{0,-5} {1,-20} {2,-12} {3,-12} {4,-15}", 
                        "ID", "Nombre", "Inicio", "Fin", "Descuento");
                    Console.WriteLine(new string('-', 70));
                    
                    foreach (var plan in planes)
                    {
                        Console.WriteLine("{0,-5} {1,-20} {2,-12} {3,-12} {4,-15}", 
                            plan.Id, 
                            plan.Nombre.Length > 17 ? plan.Nombre.Substring(0, 17) + "..." : plan.Nombre,
                            plan.FechaInicio.ToString("dd/MM/yyyy"),
                            plan.FechaFin.ToString("dd/MM/yyyy"),
                            plan.Descuento.ToString("P"));
                        
                        // Mostrar productos del plan
                        Console.WriteLine("  Productos en promoción:");
                        if (!plan.Productos.Any())
                        {
                            Console.WriteLine("    No hay productos asignados a este plan.");
                        }
                        else
                        {
                            foreach (var producto in plan.Productos)
                            {
                                Console.WriteLine($"    - {producto.Id}: {producto.Nombre}");
                            }
                        }
                        
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al obtener planes vigentes: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task AgregarProductosAlPlan(Plan plan)
        {
            bool agregarMasProductos = true;
            
            // Primero obtener todos los productos para mostrar una lista
            var todosProductos = await _productoRepository.GetAllAsync();
            
            if (!todosProductos.Any())
            {
                MenuPrincipal.MostrarMensaje("\nNo hay productos disponibles para agregar al plan.", ConsoleColor.Yellow);
                return;
            }
            
            while (agregarMasProductos)
            {
                Console.Clear();
                MenuPrincipal.MostrarEncabezado("AGREGAR PRODUCTOS AL PLAN");
                
                Console.WriteLine("\nProductos disponibles:");
                Console.WriteLine("{0,-10} {1,-30} {2,-8}", "ID", "Nombre", "Stock");
                Console.WriteLine(new string('-', 50));
                
                foreach (var producto in todosProductos)
                {
                    // No mostrar productos que ya están en el plan
                    if (!plan.Productos.Any(p => p.Id == producto.Id))
                    {
                        Console.WriteLine("{0,-10} {1,-30} {2,-8}", 
                            producto.Id, 
                            producto.Nombre.Length > 27 ? producto.Nombre.Substring(0, 27) + "..." : producto.Nombre, 
                            producto.Stock);
                    }
                }
                
                // Mostrar productos ya agregados
                if (plan.Productos.Any())
                {
                    Console.WriteLine("\nProductos ya agregados al plan:");
                    foreach (var producto in plan.Productos)
                    {
                        Console.WriteLine($"- {producto.Id}: {producto.Nombre}");
                    }
                }
                
                string productoId = MenuPrincipal.LeerEntrada("\nIngrese el ID del producto a agregar (0 para terminar): ");
                
                if (productoId == "0")
                {
                    agregarMasProductos = false;
                }
                else
                {
                    // Verificar si el producto ya está en el plan
                    if (plan.Productos.Any(p => p.Id == productoId))
                    {
                        MenuPrincipal.MostrarMensaje("\nEl producto ya está agregado al plan.", ConsoleColor.Yellow);
                        Console.ReadKey();
                        continue;
                    }
                    
                    // Verificar si el producto existe
                    var producto = todosProductos.FirstOrDefault(p => p.Id == productoId);
                    if (producto == null)
                    {
                        MenuPrincipal.MostrarMensaje("\nEl producto no existe.", ConsoleColor.Yellow);
                        Console.ReadKey();
                        continue;
                    }
                    
                    // Agregar el producto al plan
                    plan.Productos.Add(producto);
                    MenuPrincipal.MostrarMensaje($"\nProducto '{producto.Nombre}' agregado al plan.", ConsoleColor.Green);
                    
                    string continuar = MenuPrincipal.LeerEntrada("\n¿Desea agregar otro producto? (S/N): ");
                    agregarMasProductos = continuar.ToUpper() == "S";
                }
            }
        }
    }
}