using Microsoft.AspNetCore.Mvc;
using MegaReports.data;
using Microsoft.Data.SqlClient;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/")]
    public class DatabaseTestController : ControllerBase
    {
        private readonly SqlServerConnection _sqlConnection;

        public DatabaseTestController(SqlServerConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        [HttpGet("test")]
        public IActionResult TestConnection()
        {
            try
            {
                // Obtener la cadena de conexión desde SqlServerConnection
                var connectionString = _sqlConnection.getConnectionString();

                // Usar ADO.NET para abrir una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Abrir la conexión
                    
                    // Ejecutar una consulta simple para verificar la conexión
                    using (SqlCommand command = new SqlCommand("SELECT 1", connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Ok("Conexión exitosa a la base de datos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al conectar con la base de datos: {ex.Message}");
            }

            return StatusCode(500, "Error desconocido al conectar con la base de datos.");
        }
    }
}
