using MySql.Data.MySqlClient;
using SGI.Data;
using SGI.Models;

namespace SGI.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly TerceroRepository _terceroRepository;

        public ClienteRepository()
        {
            _terceroRepository = new TerceroRepository();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            List<Cliente> clientes = new List<Cliente>();
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT c.*, t.nombre, t.apellidos " +
                    "FROM cliente c " +
                    "LEFT JOIN tercero t ON c.tercero_id = t.id",
                    dbContext.Connection);
                
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    var cliente = new Cliente
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TerceroId = reader["tercero_id"].ToString()!,
                        FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                        FechaCompra = reader["fecha_compra"] != DBNull.Value ? Convert.ToDateTime(reader["fecha_compra"]) : null
                    };

                    // Cargar datos del tercero
                    cliente.Tercero = new Tercero
                    {
                        Id = cliente.TerceroId,
                        Nombre = reader["nombre"].ToString()!,
                        Apellidos = reader["apellidos"].ToString()!
                    };

                    clientes.Add(cliente);
                }
            }
            
            return clientes;
        }

        public async Task<Cliente?> GetByIdAsync(object id)
        {
            Cliente? cliente = null;
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT c.*, t.nombre, t.apellidos " +
                    "FROM cliente c " +
                    "LEFT JOIN tercero t ON c.tercero_id = t.id " +
                    "WHERE c.id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", id);
                
                using var reader = await command.ExecuteReaderAsync();
                
                if (await reader.ReadAsync())
                {
                    cliente = new Cliente
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TerceroId = reader["tercero_id"].ToString()!,
                        FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                        FechaCompra = reader["fecha_compra"] != DBNull.Value ? Convert.ToDateTime(reader["fecha_compra"]) : null
                    };

                    // Cargar datos del tercero
                    cliente.Tercero = new Tercero
                    {
                        Id = cliente.TerceroId,
                        Nombre = reader["nombre"].ToString()!,
                        Apellidos = reader["apellidos"].ToString()!
                    };
                }
            }
            
            return cliente;
        }

        public async Task<bool> InsertAsync(Cliente cliente)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "INSERT INTO cliente (tercero_id, fecha_nacimiento, fecha_compra) " +
                    "VALUES (@TerceroId, @FechaNacimiento, @FechaCompra)",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@TerceroId", cliente.TerceroId);
                command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                command.Parameters.AddWithValue("@FechaCompra", (object?)cliente.FechaCompra ?? DBNull.Value);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "UPDATE cliente SET tercero_id = @TerceroId, fecha_nacimiento = @FechaNacimiento, " +
                    "fecha_compra = @FechaCompra WHERE id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@TerceroId", cliente.TerceroId);
                command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                command.Parameters.AddWithValue("@FechaCompra", (object?)cliente.FechaCompra ?? DBNull.Value);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand("DELETE FROM cliente WHERE id = @Id", dbContext.Connection);
                command.Parameters.AddWithValue("@Id", id);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> ActualizarFechaCompraAsync(int clienteId, DateTime fechaCompra)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "UPDATE cliente SET fecha_compra = @FechaCompra WHERE id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", clienteId);
                command.Parameters.AddWithValue("@FechaCompra", fechaCompra);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }
    }
} 