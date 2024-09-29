using Microsoft.Data.SqlClient;
using MegaReports.data;
using Microsoft.AspNetCore.Mvc;
using MegaReports.Models;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/")]

    public class EditTecnicos: ControllerBase{
        private readonly DatabaseManager _databaseManager;

        public EditTecnicos(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [HttpPut("Tecnicos")]
        public IActionResult AddTecnico([FromBody] Tecnico tec)
        {
            // Construir la consulta de inserción SQL
            string query = "UPDATE Tecnicos SET Numero_empleado = @Numero_empleado, Nombres = @Nombres, Apellido_p = @Apellido_p, Apellido_m = @Apellido_m, CuadrillaId = @CuadrillaId WHERE Id = @TecnicoID;";

            // Crear los parámetros de la consulta basados en el objeto recibido

            var parameters = new[]
            {
                new SqlParameter("@TecnicoID", tec.id),
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
                return Ok(new { message = "Técnico modificado exitosamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al modificar técnico" });
            }
        }
    }
}