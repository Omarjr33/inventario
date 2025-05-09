using System;
using System.Linq;
using System.Threading.Tasks;
using SGI.Models;
using SGI.Repositories;

namespace SGI.UI
{
    public class MenuTerceros
    {
        private readonly TerceroRepository _terceroRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly EmpleadoRepository _empleadoRepository;
        
        public MenuTerceros()
        {
            _terceroRepository = new TerceroRepository();
            _clienteRepository = new ClienteRepository();
            _empleadoRepository = new EmpleadoRepository();
        }
        
        public void MostrarMenu()
        {
            bool regresar = false;
            
            while (!regresar)
            {
                Console.Clear();
                MenuPrincipal.MostrarEncabezado("GESTIÓN DE PERSONAS");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║            OPCIONES                ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Gestión de Terceros             ║");
                Console.WriteLine("║ 2. Gestión de Clientes             ║");
                Console.WriteLine("║ 3. Gestión de Empleados            ║");
                Console.WriteLine("║ 0. Regresar al Menú Principal      ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
                {
                    case "1":
                        GestionarTerceros();
                        break;
                    case "2":
                        GestionarClientes();
                        break;
                    case "3":
                        GestionarEmpleados();
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
        
        private void GestionarTerceros()
        {
            bool regresar = false;
            
            while (!regresar)
            {
                Console.Clear();
                MenuPrincipal.MostrarEncabezado("GESTIÓN DE TERCEROS");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║            OPCIONES                ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Listar Terceros                 ║");
                Console.WriteLine("║ 2. Buscar Tercero                  ║");
                Console.WriteLine("║ 3. Nuevo Tercero                   ║");
                Console.WriteLine("║ 4. Actualizar Tercero              ║");
                Console.WriteLine("║ 5. Eliminar Tercero                ║");
                Console.WriteLine("║ 0. Regresar                        ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
                {
                    case "1":
                        ListarTerceros().Wait();
                        break;
                    case "2":
                        BuscarTercero().Wait();
                        break;
                    case "3":
                        NuevoTercero().Wait();
                        break;
                    case "4":
                        ActualizarTercero().Wait();
                        break;
                    case "5":
                        EliminarTercero().Wait();
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
        
        private void GestionarClientes()
        {
            bool regresar = false;
            
            while (!regresar)
            {
                Console.Clear();
                MenuPrincipal.MostrarEncabezado("GESTIÓN DE CLIENTES");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║            OPCIONES                ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Listar Clientes                 ║");
                Console.WriteLine("║ 2. Buscar Cliente                  ║");
                Console.WriteLine("║ 3. Nuevo Cliente                   ║");
                Console.WriteLine("║ 4. Actualizar Cliente              ║");
                Console.WriteLine("║ 5. Eliminar Cliente                ║");
                Console.WriteLine("║ 0. Regresar                        ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
                {
                    case "1":
                        ListarClientes().Wait();
                        break;
                    case "2":
                        BuscarCliente().Wait();
                        break;
                    case "3":
                        NuevoCliente().Wait();
                        break;
                    case "4":
                        ActualizarCliente().Wait();
                        break;
                    case "5":
                        EliminarCliente().Wait();
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
        
        private void GestionarEmpleados()
        {
            bool regresar = false;
            
            while (!regresar)
            {
                Console.Clear();
                MenuPrincipal.MostrarEncabezado("GESTIÓN DE EMPLEADOS");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║            OPCIONES                ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Listar Empleados                ║");
                Console.WriteLine("║ 2. Buscar Empleado                 ║");
                Console.WriteLine("║ 3. Nuevo Empleado                  ║");
                Console.WriteLine("║ 4. Actualizar Empleado             ║");
                Console.WriteLine("║ 5. Eliminar Empleado               ║");
                Console.WriteLine("║ 0. Regresar                        ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";
                
                switch (opcion)
                {
                    case "1":
                        ListarEmpleados().Wait();
                        break;
                    case "2":
                        BuscarEmpleado().Wait();
                        break;
                    case "3":
                        NuevoEmpleado().Wait();
                        break;
                    case "4":
                        ActualizarEmpleado().Wait();
                        break;
                    case "5":
                        EliminarEmpleado().Wait();
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
        
        private async Task ListarTerceros()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("LISTA DE TERCEROS");
            
            try
            {
                var terceros = await _terceroRepository.GetAllAsync();
                
                if (!terceros.Any())
                {
                    MenuPrincipal.MostrarMensaje("\nNo hay terceros registrados.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║ {0,-15} {1,-30} {2,-30}  ║", "ID", "Nombre", "Email");
                    Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════╣");
                    
                    foreach (var tercero in terceros)
                    {
                        Console.WriteLine("║ {0,-15} {1,-30} {2,-30}  ║", 
                            tercero.Id, 
                            tercero.NombreCompleto,
                            tercero.Email);
                    }
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al listar terceros: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task BuscarTercero()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("BUSCAR TERCERO");
            
            string id = MenuPrincipal.LeerEntrada("\nIngrese el ID del tercero: ");
            
            try
            {
                var tercero = await _terceroRepository.GetByIdAsync(id);
                
                if (tercero == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl tercero no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                        INFORMACIÓN DEL TERCERO                                 ║");
                    Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ ID: {0,-70}  ║", tercero.Id);
                    Console.WriteLine("║ Nombre: {0,-67}  ║", tercero.Nombre);
                    Console.WriteLine("║ Apellidos: {0,-65}  ║", tercero.Apellidos);
                    Console.WriteLine("║ Email: {0,-69}  ║", tercero.Email);
                    Console.WriteLine("║ Tipo Documento ID: {0,-61}  ║", tercero.TipoDocumentoId);
                    Console.WriteLine("║ Tipo Tercero ID: {0,-64}  ║", tercero.TipoTerceroId);
                    Console.WriteLine("║ Ciudad ID: {0,-67}  ║", tercero.CiudadId);
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al buscar el tercero: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task NuevoTercero()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("NUEVO TERCERO");
            
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                        INGRESE LOS DATOS DEL TERCERO                           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();

                string id = MenuPrincipal.LeerEntrada("\nIngrese el ID del tercero: ");
                
                // Verificar si ya existe
                var existe = await _terceroRepository.GetByIdAsync(id);
                if (existe != null)
                {
                    MenuPrincipal.MostrarMensaje("\nError: Ya existe un tercero con ese ID.", ConsoleColor.Red);
                    Console.ReadKey();
                    return;
                }
                
                string nombre = MenuPrincipal.LeerEntrada("Ingrese el nombre: ");
                string apellidos = MenuPrincipal.LeerEntrada("Ingrese los apellidos: ");
                string email = MenuPrincipal.LeerEntrada("Ingrese el email: ");
                int tipoDocumentoId = MenuPrincipal.LeerEnteroPositivo("Ingrese el ID del tipo de documento: ");
                int tipoTerceroId = MenuPrincipal.LeerEnteroPositivo("Ingrese el ID del tipo de tercero: ");
                int ciudadId = MenuPrincipal.LeerEnteroPositivo("Ingrese el ID de la ciudad: ");
                
                var tercero = new Tercero
                {
                    Id = id,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Email = email,
                    TipoDocumentoId = tipoDocumentoId,
                    TipoTerceroId = tipoTerceroId,
                    CiudadId = ciudadId
                };
                
                bool resultado = await _terceroRepository.InsertAsync(tercero);
                
                if (resultado)
                {
                    MenuPrincipal.MostrarMensaje("\nTercero registrado correctamente.", ConsoleColor.Green);
                }
                else
                {
                    MenuPrincipal.MostrarMensaje("\nNo se pudo registrar el tercero.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al registrar el tercero: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task ActualizarTercero()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("ACTUALIZAR TERCERO");
            
            string id = MenuPrincipal.LeerEntrada("\nIngrese el ID del tercero a actualizar: ");
            
            try
            {
                var tercero = await _terceroRepository.GetByIdAsync(id);
                
                if (tercero == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl tercero no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.WriteLine($"\nTercero actual: {tercero.NombreCompleto}");
                    
                    string nombre = MenuPrincipal.LeerEntrada($"Ingrese el nuevo nombre ({tercero.Nombre}): ");
                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        tercero.Nombre = nombre;
                    }
                    
                    string apellidos = MenuPrincipal.LeerEntrada($"Ingrese los nuevos apellidos ({tercero.Apellidos}): ");
                    if (!string.IsNullOrWhiteSpace(apellidos))
                    {
                        tercero.Apellidos = apellidos;
                    }
                    
                    string email = MenuPrincipal.LeerEntrada($"Ingrese el nuevo email ({tercero.Email}): ");
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        tercero.Email = email;
                    }
                    
                    Console.Write($"Ingrese el nuevo ID de tipo de documento ({tercero.TipoDocumentoId}): ");
                    string tipoDocumentoIdStr = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(tipoDocumentoIdStr) && int.TryParse(tipoDocumentoIdStr, out int tipoDocumentoId) && tipoDocumentoId >= 0)
                    {
                        tercero.TipoDocumentoId = tipoDocumentoId;
                    }
                    
                    Console.Write($"Ingrese el nuevo ID de tipo de tercero ({tercero.TipoTerceroId}): ");
                    string tipoTerceroIdStr = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(tipoTerceroIdStr) && int.TryParse(tipoTerceroIdStr, out int tipoTerceroId) && tipoTerceroId >= 0)
                    {
                        tercero.TipoTerceroId = tipoTerceroId;
                    }
                    
                    Console.Write($"Ingrese el nuevo ID de ciudad ({tercero.CiudadId}): ");
                    string ciudadIdStr = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(ciudadIdStr) && int.TryParse(ciudadIdStr, out int ciudadId) && ciudadId >= 0)
                    {
                        tercero.CiudadId = ciudadId;
                    }
                    
                    bool resultado = await _terceroRepository.UpdateAsync(tercero);
                    
                    if (resultado)
                    {
                        MenuPrincipal.MostrarMensaje("\nTercero actualizado correctamente.", ConsoleColor.Green);
                    }
                    else
                    {
                        MenuPrincipal.MostrarMensaje("\nNo se pudo actualizar el tercero.", ConsoleColor.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al actualizar el tercero: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task EliminarTercero()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("ELIMINAR TERCERO");
            
            string id = MenuPrincipal.LeerEntrada("\nIngrese el ID del tercero a eliminar: ");
            
            try
            {
                var tercero = await _terceroRepository.GetByIdAsync(id);
                
                if (tercero == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl tercero no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.WriteLine($"\nTercero a eliminar: {tercero.NombreCompleto}");
                    
                    string confirmacion = MenuPrincipal.LeerEntrada("\n¿Está seguro de eliminar este tercero? (S/N): ");
                    
                    if (confirmacion.ToUpper() == "S")
                    {
                        bool resultado = await _terceroRepository.DeleteAsync(id);
                        
                        if (resultado)
                        {
                            MenuPrincipal.MostrarMensaje("\nTercero eliminado correctamente.", ConsoleColor.Green);
                        }
                        else
                        {
                            MenuPrincipal.MostrarMensaje("\nNo se pudo eliminar el tercero.", ConsoleColor.Red);
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
                MenuPrincipal.MostrarMensaje($"\nError al eliminar el tercero: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task ListarClientes()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("LISTA DE CLIENTES");
            
            try
            {
                var clientes = await _clienteRepository.GetAllAsync();
                
                if (!clientes.Any())
                {
                    MenuPrincipal.MostrarMensaje("\nNo hay clientes registrados.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║ {0,-5} {1,-15} {2,-30} {3,-12}  ║", "ID", "Tercero ID", "Nombre", "Última Compra");
                    Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════╣");
                    
                    foreach (var cliente in clientes)
                    {
                        Console.WriteLine("║ {0,-5} {1,-15} {2,-30} {3,-12}  ║", 
                            cliente.Id, 
                            cliente.TerceroId,
                            cliente.Tercero?.NombreCompleto ?? "N/A",
                            cliente.FechaCompra?.ToString("d") ?? "Sin compras");
                    }
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al listar clientes: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task BuscarCliente()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("BUSCAR CLIENTE");
            
            int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del cliente: ");
            
            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);
                
                if (cliente == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl cliente no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                        INFORMACIÓN DEL CLIENTE                                 ║");
                    Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ ID: {0,-70}  ║", cliente.Id);
                    Console.WriteLine("║ Tercero ID: {0,-65}  ║", cliente.TerceroId);
                    Console.WriteLine("║ Nombre: {0,-67}  ║", cliente.Tercero?.NombreCompleto ?? "N/A");
                    Console.WriteLine("║ Fecha de Nacimiento: {0,-59}  ║", cliente.FechaNacimiento.ToString("d"));
                    Console.WriteLine("║ Última Compra: {0,-65}  ║", cliente.FechaCompra?.ToString("d") ?? "Sin compras");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al buscar el cliente: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task NuevoCliente()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("NUEVO CLIENTE");
            
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                        INGRESE LOS DATOS DEL CLIENTE                           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();

                bool terceroValido = false;
                string terceroId = "";
                
                while (!terceroValido)
                {
                    terceroId = MenuPrincipal.LeerEntrada("\nIngrese el ID del tercero (0 para cancelar): ");
                    
                    if (terceroId == "0")
                    {
                        MenuPrincipal.MostrarMensaje("\nOperación cancelada.", ConsoleColor.Yellow);
                        Console.ReadKey();
                        return;
                    }
                    
                    // Verificar si el tercero existe
                    var tercero = await _terceroRepository.GetByIdAsync(terceroId);
                    if (tercero == null)
                    {
                        MenuPrincipal.MostrarMensaje("\nError: El tercero no existe. Por favor, ingrese un ID válido.", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    }
                    
                    // Verificar si ya es cliente
                    var clientes = await _clienteRepository.GetAllAsync();
                    if (clientes.Any(c => c.TerceroId == terceroId))
                    {
                        MenuPrincipal.MostrarMensaje("\nError: Este tercero ya está registrado como cliente.", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    }
                    
                    terceroValido = true;
                }
                
                DateTime fechaNacimiento = MenuPrincipal.LeerFecha("Ingrese la fecha de nacimiento (DD/MM/AAAA): ");
                
                var cliente = new Cliente
                {
                    TerceroId = terceroId,
                    FechaNacimiento = fechaNacimiento
                };
                
                bool resultado = await _clienteRepository.InsertAsync(cliente);
                
                if (resultado)
                {
                    MenuPrincipal.MostrarMensaje("\nCliente registrado correctamente.", ConsoleColor.Green);
                }
                else
                {
                    MenuPrincipal.MostrarMensaje("\nNo se pudo registrar el cliente.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al registrar el cliente: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task ActualizarCliente()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("ACTUALIZAR CLIENTE");
            
            try
            {
                int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del cliente a actualizar: ");
                
                var cliente = await _clienteRepository.GetByIdAsync(id);
                
                if (cliente == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl cliente no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    bool regresar = false;
                    while (!regresar)
                    {
                        Console.Clear();
                        MenuPrincipal.MostrarEncabezado("ACTUALIZAR CLIENTE");
                        Console.WriteLine($"\nCliente actual: {cliente.Tercero?.NombreCompleto}");
                        Console.WriteLine("\n¿Qué desea modificar?");
                        Console.WriteLine("1. ID cliente");
                        Console.WriteLine("2. Fecha de nacimiento");
                        Console.WriteLine("0. Regresar");
                        
                        Console.Write("\nSeleccione una opción: ");
                        string opcion = Console.ReadLine() ?? "";
                        
                        switch (opcion)
                        {
                            case "1":
                                string terceroId = MenuPrincipal.LeerEntrada($"Ingrese el nuevo ID del cliente ({cliente.TerceroId}): ");
                                if (!string.IsNullOrWhiteSpace(terceroId))
                                {
                                    // Verificar si el tercero existe
                                    var tercero = await _terceroRepository.GetByIdAsync(terceroId);
                                    if (tercero == null)
                                    {
                                        MenuPrincipal.MostrarMensaje("\nEl ID del cliente no existe. Por favor, ingrese un ID válido.", ConsoleColor.Red);
                                        Console.ReadKey();
                                        continue;
                                    }
                                    cliente.TerceroId = terceroId;
                                }
                                break;
                                
                            case "2":
                                DateTime fechaNacimiento = MenuPrincipal.LeerFecha($"Ingrese la nueva fecha de nacimiento ({cliente.FechaNacimiento:d}): ");
                                cliente.FechaNacimiento = fechaNacimiento;
                                break;
                                
                            case "0":
                                regresar = true;
                                continue;
                                
                            default:
                                MenuPrincipal.MostrarMensaje("\nOpción no válida. Intente nuevamente.", ConsoleColor.Yellow);
                                Console.ReadKey();
                                continue;
                        }
                        
                        bool resultado = await _clienteRepository.UpdateAsync(cliente);
                        
                        if (resultado)
                        {
                            MenuPrincipal.MostrarMensaje("\nCliente actualizado correctamente.", ConsoleColor.Green);
                        }
                        else
                        {
                            MenuPrincipal.MostrarMensaje("\nNo se pudo actualizar el cliente.", ConsoleColor.Red);
                        }
                        
                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al actualizar el cliente: {ex.Message}", ConsoleColor.Red);
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        
        private async Task EliminarCliente()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("ELIMINAR CLIENTE");
            
            int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del cliente a eliminar: ");
            
            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);
                
                if (cliente == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl cliente no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.WriteLine($"\nCliente a eliminar: {cliente.Tercero?.NombreCompleto ?? "N/A"}");
                    
                    string confirmacion = MenuPrincipal.LeerEntrada("\n¿Está seguro de eliminar este cliente? (S/N): ");
                    
                    if (confirmacion.ToUpper() == "S")
                    {
                        bool resultado = await _clienteRepository.DeleteAsync(id);
                        
                        if (resultado)
                        {
                            MenuPrincipal.MostrarMensaje("\nCliente eliminado correctamente.", ConsoleColor.Green);
                        }
                        else
                        {
                            MenuPrincipal.MostrarMensaje("\nNo se pudo eliminar el cliente.", ConsoleColor.Red);
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
                MenuPrincipal.MostrarMensaje($"\nError al eliminar el cliente: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task ListarEmpleados()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("LISTA DE EMPLEADOS");
            
            try
            {
                var empleados = await _empleadoRepository.GetAllAsync();
                
                if (!empleados.Any())
                {
                    MenuPrincipal.MostrarMensaje("\nNo hay empleados registrados.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║ {0,-5} {1,-15} {2,-30} {3,-12}  ║", "ID", "Tercero ID", "Nombre", "Salario");
                    Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════╣");
                    
                    foreach (var empleado in empleados)
                    {
                        Console.WriteLine("║ {0,-5} {1,-15} {2,-30} {3,-12:C}  ║", 
                            empleado.Id, 
                            empleado.TerceroId,
                            empleado.Tercero?.NombreCompleto ?? "N/A",
                            empleado.Salario);
                    }
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al listar empleados: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task BuscarEmpleado()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("BUSCAR EMPLEADO");
            
            int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del empleado: ");
            
            try
            {
                var empleado = await _empleadoRepository.GetByIdAsync(id);
                
                if (empleado == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl empleado no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                        INFORMACIÓN DEL EMPLEADO                                ║");
                    Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ ID: {0,-70}     ║", empleado.Id);
                    Console.WriteLine("║ Tercero ID: {0,-65}  ║", empleado.TerceroId);
                    Console.WriteLine("║ Nombre: {0,-67}    ║", empleado.Tercero?.NombreCompleto ?? "N/A");
                    Console.WriteLine("║ Fecha de Nacimiento: {0,-58}║", empleado.FechaNacimiento.ToString("d"));
                    Console.WriteLine("║ Fecha de Contratación: {0,-55} ║", empleado.FechaContratacion.ToString("d"));
                    Console.WriteLine("║ Salario: {0,-67:C}   ║", empleado.Salario);
                    Console.WriteLine("║ EPS ID: {0,-67}    ║", empleado.EpsId);
                    Console.WriteLine("║ ARL ID: {0,-67}    ║", empleado.ArlId);
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al buscar el empleado: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task NuevoEmpleado()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("NUEVO EMPLEADO");
            
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                        INGRESE LOS DATOS DEL EMPLEADO                            ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();

                string terceroId = MenuPrincipal.LeerEntrada("\nIngrese el ID del tercero: ");
                
                // Verificar si el tercero existe
                var tercero = await _terceroRepository.GetByIdAsync(terceroId);
                if (tercero == null)
                {
                    MenuPrincipal.MostrarMensaje("\nError: El tercero no existe.", ConsoleColor.Red);
                    Console.ReadKey();
                    return;
                }
                
                DateTime fechaNacimiento = MenuPrincipal.LeerFecha("Ingrese la fecha de nacimiento (DD/MM/AAAA): ");
                DateTime fechaContratacion = MenuPrincipal.LeerFecha("Ingrese la fecha de contratación (DD/MM/AAAA): ");
                decimal salario = MenuPrincipal.LeerDecimalPositivo("Ingrese el salario: ");
                string cargo = MenuPrincipal.LeerEntrada("Ingrese el cargo: ");
                
                var empleado = new Empleado
                {
                    TerceroId = terceroId,
                    FechaNacimiento = fechaNacimiento,
                    FechaContratacion = fechaContratacion,
                    Salario = salario,
                    Cargo = cargo
                };
                
                bool resultado = await _empleadoRepository.InsertAsync(empleado);
                
                if (resultado)
                {
                    MenuPrincipal.MostrarMensaje("\nEmpleado registrado correctamente.", ConsoleColor.Green);
                }
                else
                {
                    MenuPrincipal.MostrarMensaje("\nNo se pudo registrar el empleado.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al registrar el empleado: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private async Task ActualizarEmpleado()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("ACTUALIZAR EMPLEADO");
            
            try
            {
                int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del empleado a actualizar: ");
                
                var empleado = await _empleadoRepository.GetByIdAsync(id);
                
                if (empleado == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl empleado no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    bool regresar = false;
                    while (!regresar)
                    {
                        Console.Clear();
                        MenuPrincipal.MostrarEncabezado("ACTUALIZAR EMPLEADO");
                        Console.WriteLine($"\nEmpleado actual: {empleado.Tercero?.NombreCompleto}");
                        Console.WriteLine("\n¿Qué desea modificar?");
                        Console.WriteLine("1. ID empleado");
                        Console.WriteLine("2. Fecha de contratación");
                        Console.WriteLine("3. Salario");
                        Console.WriteLine("4. EPS");
                        Console.WriteLine("5. ARL");
                        Console.WriteLine("0. Regresar");
                        
                        Console.Write("\nSeleccione una opción: ");
                        string opcion = Console.ReadLine() ?? "";
                        
                        switch (opcion)
                        {
                            case "1":
                                string terceroId = MenuPrincipal.LeerEntrada($"Ingrese el nuevo ID del empleado ({empleado.TerceroId}): ");
                                if (!string.IsNullOrWhiteSpace(terceroId))
                                {
                                    // Verificar si el tercero existe
                                    var tercero = await _terceroRepository.GetByIdAsync(terceroId);
                                    if (tercero == null)
                                    {
                                        MenuPrincipal.MostrarMensaje("\nEl ID del empleado no existe. Por favor, ingrese un ID válido.", ConsoleColor.Red);
                                        Console.ReadKey();
                                        continue;
                                    }
                                    empleado.TerceroId = terceroId;
                                }
                                break;
                                
                            case "2":
                                DateTime fechaContratacion = MenuPrincipal.LeerFecha($"Ingrese la nueva fecha de contratación ({empleado.FechaContratacion:d}): ");
                                empleado.FechaContratacion = fechaContratacion;
                                break;
                                
                            case "3":
                                decimal salario = MenuPrincipal.LeerDecimalPositivo($"Ingrese el nuevo salario ({empleado.Salario:C}): ");
                                empleado.Salario = salario;
                                break;
                                
                            case "4":
                                int epsId = MenuPrincipal.LeerEnteroPositivo($"Ingrese el nuevo ID de EPS ({empleado.EpsId}): ");
                                empleado.EpsId = epsId;
                                break;
                                
                            case "5":
                                int arlId = MenuPrincipal.LeerEnteroPositivo($"Ingrese el nuevo ID de ARL ({empleado.ArlId}): ");
                                empleado.ArlId = arlId;
                                break;
                                
                            case "0":
                                regresar = true;
                                continue;
                                
                            default:
                                MenuPrincipal.MostrarMensaje("\nOpción no válida. Intente nuevamente.", ConsoleColor.Yellow);
                                Console.ReadKey();
                                continue;
                        }
                        
                        bool resultado = await _empleadoRepository.UpdateAsync(empleado);
                        
                        if (resultado)
                        {
                            MenuPrincipal.MostrarMensaje("\nEmpleado actualizado correctamente.", ConsoleColor.Green);
                        }
                        else
                        {
                            MenuPrincipal.MostrarMensaje("\nNo se pudo actualizar el empleado.", ConsoleColor.Red);
                        }
                        
                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                MenuPrincipal.MostrarMensaje($"\nError al actualizar el empleado: {ex.Message}", ConsoleColor.Red);
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        
        private async Task EliminarEmpleado()
        {
            Console.Clear();
            MenuPrincipal.MostrarEncabezado("ELIMINAR EMPLEADO");
            
            int id = MenuPrincipal.LeerEnteroPositivo("\nIngrese el ID del empleado a eliminar: ");
            
            try
            {
                var empleado = await _empleadoRepository.GetByIdAsync(id);
                
                if (empleado == null)
                {
                    MenuPrincipal.MostrarMensaje("\nEl empleado no existe.", ConsoleColor.Yellow);
                }
                else
                {
                    Console.WriteLine($"\nEmpleado a eliminar: {empleado.Tercero?.NombreCompleto ?? "N/A"}");
                    
                    string confirmacion = MenuPrincipal.LeerEntrada("\n¿Está seguro de eliminar este empleado? (S/N): ");
                    
                    if (confirmacion.ToUpper() == "S")
                    {
                        bool resultado = await _empleadoRepository.DeleteAsync(id);
                        
                        if (resultado)
                        {
                            MenuPrincipal.MostrarMensaje("\nEmpleado eliminado correctamente.", ConsoleColor.Green);
                        }
                        else
                        {
                            MenuPrincipal.MostrarMensaje("\nNo se pudo eliminar el empleado.", ConsoleColor.Red);
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
                MenuPrincipal.MostrarMensaje($"\nError al eliminar el empleado: {ex.Message}", ConsoleColor.Red);
            }
            
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
} 