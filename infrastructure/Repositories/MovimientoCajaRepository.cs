using MySql.Data.MySqlClient;
using SGI.Data;
using SGI.Models;

namespace SGI.Repositories
{
    public class MovimientoCajaRepository : IRepository<MovimientoCaja>
    {
        public async Task<IEnumerable<MovimientoCaja>> GetAllAsync()
        {
            List<MovimientoCaja> movimientos = new List<MovimientoCaja>();
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT m.*, tm.nombre as tipo_nombre, tm.tipoMovimiento, " +
                    "t.nombre as tercero_nombre, t.apellidos as tercero_apellidos " +
                    "FROM movimientoCaja m " +
                    "JOIN tipoMovCaja tm ON m.tipoMovimiento_id = tm.id " +
                    "JOIN tercero t ON m.tercero_id = t.id " +
                    "ORDER BY m.fecha DESC",
                    dbContext.Connection);
                
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    movimientos.Add(new MovimientoCaja
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Fecha = Convert.ToDateTime(reader["fecha"]),
                        TipoMovimientoId = Convert.ToInt32(reader["tipoMovimiento_id"]),
                        Valor = Convert.ToDecimal(reader["valor"]),
                        Concepto = reader["concepto"].ToString()!,
                        TerceroId = reader["tercero_id"].ToString()!,
                        TipoMovimientoNombre = reader["tipo_nombre"].ToString(),
                        TipoMovimiento = reader["tipoMovimiento"].ToString(),
                        Tercero = new Tercero
                        {
                            Id = reader["tercero_id"].ToString()!,
                            Nombre = reader["tercero_nombre"].ToString()!,
                            Apellidos = reader["tercero_apellidos"].ToString()!
                        }
                    });
                }
            }
            
            return movimientos;
        }

        public async Task<MovimientoCaja?> GetByIdAsync(object id)
        {
            MovimientoCaja? movimiento = null;
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT m.*, tm.nombre as tipo_nombre, tm.tipoMovimiento, " +
                    "t.nombre as tercero_nombre, t.apellidos as tercero_apellidos " +
                    "FROM movimientoCaja m " +
                    "JOIN tipoMovCaja tm ON m.tipoMovimiento_id = tm.id " +
                    "JOIN tercero t ON m.tercero_id = t.id " +
                    "WHERE m.id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", id);
                
                using var reader = await command.ExecuteReaderAsync();
                
                if (await reader.ReadAsync())
                {
                    movimiento = new MovimientoCaja
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Fecha = Convert.ToDateTime(reader["fecha"]),
                        TipoMovimientoId = Convert.ToInt32(reader["tipoMovimiento_id"]),
                        Valor = Convert.ToDecimal(reader["valor"]),
                        Concepto = reader["concepto"].ToString()!,
                        TerceroId = reader["tercero_id"].ToString()!,
                        TipoMovimientoNombre = reader["tipo_nombre"].ToString(),
                        TipoMovimiento = reader["tipoMovimiento"].ToString(),
                        Tercero = new Tercero
                        {
                            Id = reader["tercero_id"].ToString()!,
                            Nombre = reader["tercero_nombre"].ToString()!,
                            Apellidos = reader["tercero_apellidos"].ToString()!
                        }
                    };
                }
            }
            
            return movimiento;
        }

        public async Task<bool> InsertAsync(MovimientoCaja movimiento)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "INSERT INTO movimientoCaja (fecha, tipoMovimiento_id, valor, concepto, tercero_id) " +
                    "VALUES (@Fecha, @TipoMovimientoId, @Valor, @Concepto, @TerceroId)",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                command.Parameters.AddWithValue("@TipoMovimientoId", movimiento.TipoMovimientoId);
                command.Parameters.AddWithValue("@Valor", movimiento.Valor);
                command.Parameters.AddWithValue("@Concepto", movimiento.Concepto);
                command.Parameters.AddWithValue("@TerceroId", movimiento.TerceroId);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> UpdateAsync(MovimientoCaja movimiento)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "UPDATE movimientoCaja SET fecha = @Fecha, tipoMovimiento_id = @TipoMovimientoId, " +
                    "valor = @Valor, concepto = @Concepto, tercero_id = @TerceroId " +
                    "WHERE id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", movimiento.Id);
                command.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                command.Parameters.AddWithValue("@TipoMovimientoId", movimiento.TipoMovimientoId);
                command.Parameters.AddWithValue("@Valor", movimiento.Valor);
                command.Parameters.AddWithValue("@Concepto", movimiento.Concepto);
                command.Parameters.AddWithValue("@TerceroId", movimiento.TerceroId);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "DELETE FROM movimientoCaja WHERE id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", id);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }
        
        // Métodos específicos para MovimientoCaja
        public async Task<decimal> GetSaldoCajaAsync(DateTime fecha)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT SUM(CASE WHEN tm.tipoMovimiento = 'Entrada' THEN m.valor ELSE -m.valor END) as saldo " +
                    "FROM movimientoCaja m " +
                    "JOIN tipoMovCaja tm ON m.tipoMovimiento_id = tm.id " +
                    "WHERE DATE(m.fecha) = DATE(@Fecha)",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Fecha", fecha);
                
                var result = await command.ExecuteScalarAsync();
                
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                
                return 0;
            }
        }
        
        public async Task<IEnumerable<MovimientoCaja>> GetMovimientosByFechaAsync(DateTime fecha)
        {
            List<MovimientoCaja> movimientos = new List<MovimientoCaja>();
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT m.*, tm.nombre as tipo_nombre, tm.tipoMovimiento, " +
                    "t.nombre as tercero_nombre, t.apellidos as tercero_apellidos " +
                    "FROM movimientoCaja m " +
                    "JOIN tipoMovCaja tm ON m.tipoMovimiento_id = tm.id " +
                    "JOIN tercero t ON m.tercero_id = t.id " +
                    "WHERE DATE(m.fecha) = DATE(@Fecha) " +
                    "ORDER BY m.fecha DESC",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Fecha", fecha);
                
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    movimientos.Add(new MovimientoCaja
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Fecha = Convert.ToDateTime(reader["fecha"]),
                        TipoMovimientoId = Convert.ToInt32(reader["tipoMovimiento_id"]),
                        Valor = Convert.ToDecimal(reader["valor"]),
                        Concepto = reader["concepto"].ToString()!,
                        TerceroId = reader["tercero_id"].ToString()!,
                        TipoMovimientoNombre = reader["tipo_nombre"].ToString(),
                        TipoMovimiento = reader["tipoMovimiento"].ToString(),
                        Tercero = new Tercero
                        {
                            Id = reader["tercero_id"].ToString()!,
                            Nombre = reader["tercero_nombre"].ToString()!,
                            Apellidos = reader["tercero_apellidos"].ToString()!
                        }
                    });
                }
            }
            
            return movimientos;
        }
    }
}