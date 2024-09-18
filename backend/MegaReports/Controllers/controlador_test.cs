using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient; 
using MegaReports.data;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Abrir la conexión
                    return Ok("Conexión exitosa a la base de datos."); // Si se conecta correctamente
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al conectar con la base de datos: {ex.Message}");
            }
        }
    }
}
