using MySql.Data.MySqlClient;
using SGI.Data;
using SGI.Models;

namespace SGI.Repositories
{
    public class VentaRepository : IRepository<Venta>
    {
        private readonly ProductoRepository _productoRepository;
        
        public VentaRepository()
        {
            _productoRepository = new ProductoRepository();
        }
        
        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            List<Venta> ventas = new List<Venta>();
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT v.*, " +
                    "tc.nombre as cliente_nombre, tc.apellidos as cliente_apellidos, " +
                    "te.nombre as empleado_nombre, te.apellidos as empleado_apellidos " +
                    "FROM venta v " +
                    "JOIN tercero tc ON v.terceroCliente_id = tc.id " +
                    "JOIN tercero te ON v.terceroEmpleado_id = te.id " +
                    "ORDER BY v.fecha DESC",
                    dbContext.Connection);
                
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    var venta = new Venta
                    {
                        FacturaId = Convert.ToInt32(reader["factura_id"]),
                        Fecha = Convert.ToDateTime(reader["fecha"]),
                        TerceroEmpleadoId = reader["terceroEmpleado_id"].ToString()!,
                        TerceroClienteId = reader["terceroCliente_id"].ToString()!,
                        Cliente = new Tercero
                        {
                            Id = reader["terceroCliente_id"].ToString()!,
                            Nombre = reader["cliente_nombre"].ToString()!,
                            Apellidos = reader["cliente_apellidos"].ToString()!
                        },
                        Empleado = new Tercero
                        {
                            Id = reader["terceroEmpleado_id"].ToString()!,
                            Nombre = reader["empleado_nombre"].ToString()!,
                            Apellidos = reader["empleado_apellidos"].ToString()!
                        }
                    };
                    
                    ventas.Add(venta);
                }
            }
            
            // Cargar los detalles para cada venta
            foreach (var venta in ventas)
            {
                venta.Detalles = (await GetDetallesVentaAsync(venta.FacturaId)).ToList();
            }
            
            return ventas;
        }

        public async Task<Venta?> GetByIdAsync(object id)
        {
            Venta? venta = null;
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT v.*, " +
                    "tc.nombre as cliente_nombre, tc.apellidos as cliente_apellidos, " +
                    "te.nombre as empleado_nombre, te.apellidos as empleado_apellidos " +
                    "FROM venta v " +
                    "JOIN tercero tc ON v.terceroCliente_id = tc.id " +
                    "JOIN tercero te ON v.terceroEmpleado_id = te.id " +
                    "WHERE v.factura_id = @FacturaId",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@FacturaId", id);
                
                using var reader = await command.ExecuteReaderAsync();
                
                if (await reader.ReadAsync())
                {
                    venta = new Venta
                    {
                        FacturaId = Convert.ToInt32(reader["factura_id"]),
                        Fecha = Convert.ToDateTime(reader["fecha"]),
                        TerceroEmpleadoId = reader["terceroEmpleado_id"].ToString()!,
                        TerceroClienteId = reader["terceroCliente_id"].ToString()!,
                        Cliente = new Tercero
                        {
                            Id = reader["terceroCliente_id"].ToString()!,
                            Nombre = reader["cliente_nombre"].ToString()!,
                            Apellidos = reader["cliente_apellidos"].ToString()!
                        },
                        Empleado = new Tercero
                        {
                            Id = reader["terceroEmpleado_id"].ToString()!,
                            Nombre = reader["empleado_nombre"].ToString()!,
                            Apellidos = reader["empleado_apellidos"].ToString()!
                        }
                    };
                    
                    // Cargar los detalles de la venta
                    venta.Detalles = (await GetDetallesVentaAsync(venta.FacturaId)).ToList();
                }
            }
            
            return venta;
        }

        public async Task<bool> InsertAsync(Venta venta)
        {
            using (var dbContext = new DbContext())
            {
                using var transaction = await dbContext.Connection.BeginTransactionAsync();
                
                try
                {
                    // Obtener el próximo número de factura
                    int facturaId = await GetNextFacturaIdAsync(dbContext);
                    venta.FacturaId = facturaId;
                    facturaId++;
                    
                    // Insertar la venta
                    using var commandVenta = new MySqlCommand(
                        "INSERT INTO venta (factura_id, fecha, terceroEmpleado_id, terceroCliente_id) " +
                        "VALUES (@FacturaId, @Fecha, @TerceroEmpleadoId, @TerceroClienteId)",
                        dbContext.Connection);
                    
                    commandVenta.Parameters.AddWithValue("@FacturaId", facturaId);
                    commandVenta.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    commandVenta.Parameters.AddWithValue("@TerceroEmpleadoId", venta.TerceroEmpleadoId);
                    commandVenta.Parameters.AddWithValue("@TerceroClienteId", venta.TerceroClienteId);
                    
                    await commandVenta.ExecuteNonQueryAsync();
                    
                    // Insertar los detalles de la venta
                    foreach (var detalle in venta.Detalles)
                    {
                        using var commandDetalle = new MySqlCommand(
                            "INSERT INTO detalle_venta (factura_id, producto_id, cantidad, valor) " +
                            "VALUES (@FacturaId, @ProductoId, @Cantidad, @Valor)",
                            dbContext.Connection);
                        
                        commandDetalle.Parameters.AddWithValue("@FacturaId", facturaId);
                        commandDetalle.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                        commandDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        commandDetalle.Parameters.AddWithValue("@Valor", detalle.Valor);
                        
                        await commandDetalle.ExecuteNonQueryAsync();
                        
                        // Actualizar el stock del producto (restar)
                        await _productoRepository.ActualizarStockAsync(detalle.ProductoId, -detalle.Cantidad, dbContext.Connection);
                    }
                    
                    // Actualizar el contador de facturas
                    await UpdateFacturacionAsync(dbContext, facturaId);
                    
                    // Actualizar la fecha de compra del cliente
                    await UpdateClienteFechaCompraAsync(dbContext, venta.TerceroClienteId, venta.Fecha);
                    
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<bool> UpdateAsync(Venta venta)
        {
            // La actualización de ventas no se implementará por simplicidad
            // ya que implica manejar la reversión de stock y otros detalles complejos
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(object id)
        {
            // La eliminación de ventas no se implementará por simplicidad
            // ya que implica manejar la reversión de stock y otros detalles complejos
            return await Task.FromResult(false);
        }
        
        // Métodos específicos para Venta
        private async Task<IEnumerable<DetalleVenta>> GetDetallesVentaAsync(int facturaId)
        {
            List<DetalleVenta> detalles = new List<DetalleVenta>();
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT dv.*, p.nombre as producto_nombre " +
                    "FROM detalle_venta dv " +
                    "JOIN producto p ON dv.producto_id = p.id " +
                    "WHERE dv.factura_id = @FacturaId",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@FacturaId", facturaId);
                
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    detalles.Add(new DetalleVenta
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FacturaId = facturaId,
                        ProductoId = reader["producto_id"].ToString()!,
                        Cantidad = Convert.ToInt32(reader["cantidad"]),
                        Valor = Convert.ToDecimal(reader["valor"]),
                        Producto = new Producto
                        {
                            Id = reader["producto_id"].ToString()!,
                            Nombre = reader["producto_nombre"].ToString()!
                        }
                    });
                }
            }
            
            return detalles;
        }
        
        private async Task<int> GetNextFacturaIdAsync(DbContext dbContext)
        {
            using var command = new MySqlCommand(
                "SELECT factura_actual FROM facturacion LIMIT 1",
                dbContext.Connection);
            
            var result = await command.ExecuteScalarAsync();
            
            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result) + 1;
            }
            else
            {
                // Si no hay configuración de facturación, crear una por defecto
                using var createCommand = new MySqlCommand(
                    "INSERT INTO facturacion (fechaResolucion, numInicio, numFinal, factura_actual) " +
                    "VALUES (NOW(), 1, 1000, 1)",
                    dbContext.Connection);
                
                await createCommand.ExecuteNonQueryAsync();
                return 1;
            }
        }
        
        private async Task UpdateFacturacionAsync(DbContext dbContext, int facturaId)
        {
            using var command = new MySqlCommand(
                "UPDATE facturacion SET factura_actual = @FacturaId",
                dbContext.Connection);
            
            command.Parameters.AddWithValue("@FacturaId", facturaId);
            
            await command.ExecuteNonQueryAsync();
        }
        
        private async Task UpdateClienteFechaCompraAsync(DbContext dbContext, string terceroId, DateTime fechaCompra)
        {
            // Buscar el registro de cliente asociado al tercero
            using var findCommand = new MySqlCommand(
                "SELECT id FROM cliente WHERE tercero_id = @TerceroId",
                dbContext.Connection);
            
            findCommand.Parameters.AddWithValue("@TerceroId", terceroId);
            
            var clienteId = await findCommand.ExecuteScalarAsync();
            
            if (clienteId != null && clienteId != DBNull.Value)
            {
                // Actualizar la fecha de compra
                using var updateCommand = new MySqlCommand(
                    "UPDATE cliente SET fecha_compra = @FechaCompra WHERE id = @ClienteId",
                    dbContext.Connection);
                
                updateCommand.Parameters.AddWithValue("@ClienteId", clienteId);
                updateCommand.Parameters.AddWithValue("@FechaCompra", fechaCompra);
                
                await updateCommand.ExecuteNonQueryAsync();
            }
        }
    }
}