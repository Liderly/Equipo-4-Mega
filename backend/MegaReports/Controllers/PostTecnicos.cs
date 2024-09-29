using Microsoft.Data.SqlClient;
using MegaReports.data;
using Microsoft.AspNetCore.Mvc;
using MegaReports.Models;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/")]

    public class PostTecnicos: ControllerBase{
        private readonly DatabaseManager _databaseManager;

        public PostTecnicos(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [HttpPost("Tecnicos")]
        public IActionResult AddTecnico([FromBody] Tecnico tec)
        {
            // Construir la consulta de inserción SQL
            string query = "INSERT INTO Tecnicos (Numero_empleado, Nombres, Apellido_p, Apellido_m, CuadrillaId) " +
                        "VALUES (@Numero_empleado, @Nombres, @Apellido_p, @Apellido_m, @CuadrillaId);";

            // Crear los parámetros de la consulta basados en el objeto recibido

            var parameters = new[]
            {
                new SqlParameter("@Numero_empleado", tec.Numero_empleado),
                new SqlParameter("@Nombres", tec.nombre),
                new SqlParameter("@Apellido_p", tec.apellido_P),
                new SqlParameter("@Apellido_m", tec.apellido_M),
                new SqlParameter("@CuadrillaId", tec.cuadrillaId),
            };

            // Ejecutar la consulta
            var data = _databaseManager.ExecuteQuery(query, parameters);

            // Validar si la inserción fue exitosa
            if (data != null)
            {
                return Ok(new { message = "Técnico agregado exitosamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al agregar técnico" });
            }
        }
    }
}