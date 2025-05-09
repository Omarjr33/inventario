using MySql.Data.MySqlClient;
using SGI.Data;
using SGI.Models;

namespace SGI.Repositories
{
    public class TerceroRepository : IRepository<Tercero>
    {
        public async Task<IEnumerable<Tercero>> GetAllAsync()
        {
            List<Tercero> terceros = new List<Tercero>();
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand("SELECT * FROM tercero", dbContext.Connection);
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    terceros.Add(new Tercero
                    {
                        Id = reader["id"].ToString()!,
                        Nombre = reader["nombre"].ToString()!,
                        Apellidos = reader["apellidos"].ToString()!,
                        Email = reader["email"].ToString()!,
                        TipoDocumentoId = Convert.ToInt32(reader["tipo_documento_id"]),
                        TipoTerceroId = Convert.ToInt32(reader["tipo_tercero_id"]),
                        CiudadId = Convert.ToInt32(reader["ciudad_id"])
                    });
                }
            }
            
            return terceros;
        }

        public async Task<Tercero?> GetByIdAsync(object id)
        {
            Tercero? tercero = null;
            
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand("SELECT * FROM tercero WHERE id = @Id", dbContext.Connection);
                command.Parameters.AddWithValue("@Id", id);
                
                using var reader = await command.ExecuteReaderAsync();
                
                if (await reader.ReadAsync())
                {
                    tercero = new Tercero
                    {
                        Id = reader["id"].ToString()!,
                        Nombre = reader["nombre"].ToString()!,
                        Apellidos = reader["apellidos"].ToString()!,
                        Email = reader["email"].ToString()!,
                        TipoDocumentoId = Convert.ToInt32(reader["tipo_documento_id"]),
                        TipoTerceroId = Convert.ToInt32(reader["tipo_tercero_id"]),
                        CiudadId = Convert.ToInt32(reader["ciudad_id"])
                    };
                }
            }
            
            return tercero;
        }

        public async Task<bool> InsertAsync(Tercero tercero)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "INSERT INTO tercero (id, nombre, apellidos, email, tipo_documento_id, tipo_tercero_id, ciudad_id) " +
                    "VALUES (@Id, @Nombre, @Apellidos, @Email, @TipoDocumentoId, @TipoTerceroId, @CiudadId)",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", tercero.Id);
                command.Parameters.AddWithValue("@Nombre", tercero.Nombre);
                command.Parameters.AddWithValue("@Apellidos", tercero.Apellidos);
                command.Parameters.AddWithValue("@Email", tercero.Email);
                command.Parameters.AddWithValue("@TipoDocumentoId", tercero.TipoDocumentoId);
                command.Parameters.AddWithValue("@TipoTerceroId", tercero.TipoTerceroId);
                command.Parameters.AddWithValue("@CiudadId", tercero.CiudadId);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> UpdateAsync(Tercero tercero)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand(
                    "UPDATE tercero SET nombre = @Nombre, apellidos = @Apellidos, email = @Email, " +
                    "tipo_documento_id = @TipoDocumentoId, tipo_tercero_id = @TipoTerceroId, ciudad_id = @CiudadId " +
                    "WHERE id = @Id",
                    dbContext.Connection);
                
                command.Parameters.AddWithValue("@Id", tercero.Id);
                command.Parameters.AddWithValue("@Nombre", tercero.Nombre);
                command.Parameters.AddWithValue("@Apellidos", tercero.Apellidos);
                command.Parameters.AddWithValue("@Email", tercero.Email);
                command.Parameters.AddWithValue("@TipoDocumentoId", tercero.TipoDocumentoId);
                command.Parameters.AddWithValue("@TipoTerceroId", tercero.TipoTerceroId);
                command.Parameters.AddWithValue("@CiudadId", tercero.CiudadId);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            using (var dbContext = new DbContext())
            {
                using var command = new MySqlCommand("DELETE FROM tercero WHERE id = @Id", dbContext.Connection);
                command.Parameters.AddWithValue("@Id", id);
                
                return await command.ExecuteNonQueryAsync() > 0;
            }
        }
    }
} 