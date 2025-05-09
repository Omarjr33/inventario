using MySql.Data.MySqlClient;
using SGI.Data;
using SGI.Models;

namespace SGI.Repositories
{
    public class EmpleadoRepository : IRepository<Empleado>
    {
        private readonly TerceroRepository _terceroRepository;

        public EmpleadoRepository()
        {
            _terceroRepository = new TerceroRepository();
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            List<Empleado> empleados = new List<Empleado>();
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT e.*, t.nombre, t.apellidos " +
                    "FROM empleado e " +
                    "LEFT JOIN tercero t ON e.tercero_id = t.id",
                    dbContext.Connection);
                
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    var empleado = new Empleado
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TerceroId = reader["tercero_id"].ToString()!,
                        FechaContratacion = Convert.ToDateTime(reader["fecha_ingreso"]),
                        Salario = Convert.ToDecimal(reader["salario_base"]),
                        EpsId = Convert.ToInt32(reader["eps_id"]),
                        ArlId = Convert.ToInt32(reader["arl_id"])
                    };

                    // Cargar datos del tercero
                    empleado.Tercero = new Tercero
                    {
                        Id = empleado.TerceroId,
                        Nombre = reader["nombre"].ToString()!,
                        Apellidos = reader["apellidos"].ToString()!
                    };

                    empleados.Add(empleado);
                }
            }
            
            return empleados;
        }

        public async Task<Empleado?> GetByIdAsync(object id)
        {
            Empleado? empleado = null;
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "SELECT e.*, t.nombre, t.apellidos " +
                    "FROM empleado e " +
                    "LEFT JOIN tercero t ON e.tercero_id = t.id " +
                    "WHERE e.id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", id);
                
                using var reader = await command.ExecuteReaderAsync();
                
                if (await reader.ReadAsync())
                {
                    empleado = new Empleado
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TerceroId = reader["tercero_id"].ToString()!,
                        FechaContratacion = Convert.ToDateTime(reader["fecha_ingreso"]),
                        Salario = Convert.ToDecimal(reader["salario_base"]),
                        EpsId = Convert.ToInt32(reader["eps_id"]),
                        ArlId = Convert.ToInt32(reader["arl_id"])
                    };

                    // Cargar datos del tercero
                    empleado.Tercero = new Tercero
                    {
                        Id = empleado.TerceroId,
                        Nombre = reader["nombre"].ToString()!,
                        Apellidos = reader["apellidos"].ToString()!
                    };
                }
            }
            
            return empleado;
        }

        public async Task<bool> InsertAsync(Empleado empleado)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "INSERT INTO empleado (tercero_id, fecha_ingreso, salario_base, eps_id, arl_id) " +
                    "VALUES (@TerceroId, @FechaContratacion, @Salario, @EpsId, @ArlId)",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@TerceroId", empleado.TerceroId);
                command.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion);
                command.Parameters.AddWithValue("@Salario", empleado.Salario);
                command.Parameters.AddWithValue("@EpsId", empleado.EpsId);
                command.Parameters.AddWithValue("@ArlId", empleado.ArlId);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> UpdateAsync(Empleado empleado)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "UPDATE empleado SET tercero_id = @TerceroId, fecha_ingreso = @FechaContratacion, " +
                    "salario_base = @Salario, eps_id = @EpsId, arl_id = @ArlId " +
                    "WHERE id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", empleado.Id);
                command.Parameters.AddWithValue("@TerceroId", empleado.TerceroId);
                command.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion);
                command.Parameters.AddWithValue("@Salario", empleado.Salario);
                command.Parameters.AddWithValue("@EpsId", empleado.EpsId);
                command.Parameters.AddWithValue("@ArlId", empleado.ArlId);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand("DELETE FROM empleado WHERE id = @Id", dbContext.Connection);
                command.Parameters.AddWithValue("@Id", id);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> ActualizarSalarioAsync(int empleadoId, decimal nuevoSalario)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "UPDATE empleado SET salario_base = @Salario WHERE id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", empleadoId);
                command.Parameters.AddWithValue("@Salario", nuevoSalario);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }
    }
} 