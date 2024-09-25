using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using MegaReports.Models;
using MegaReports.data;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/")]

    public class CRUDTabulator: ControllerBase
    {
        private readonly DatabaseManager _databaseManager;
        public CRUDTabulator(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [HttpGet("Tabulator")]
        public IActionResult GetTabulator()
        {
            string query = "SELECT * FROM Bonos;";

            var data = _databaseManager.ExecuteQuery(query);
            var DesData = new List<Dictionary<string, object>>();
            foreach (DataRow row in data.Rows)
            {
                var Tabulator = new Dictionary<string, object>();
                foreach (DataColumn column in data.Columns)
                {
                    Tabulator.Add(column.ColumnName, row[column]);
                }
                DesData.Add(Tabulator);
            }
            return Ok(DesData);
        }

        [HttpPost("UpdatePuntos")]
        public IActionResult UpdatePuntosRange([FromBody] Bonos bonos) // Nota colocar los try catch
        {
            string query = @"UPDATE Bonos
                            SET Puntos_minimos = @Puntos_minimos, Puntos_maximos = @Puntos_maximos
                            WHERE Id = @Id;";
            var parameters = new []
            {
                new SqlParameter("@Id", bonos.Id),
                new SqlParameter("@Puntos_minimos", bonos.Puntos_minimos),
                new SqlParameter("@Puntos_maximos", bonos.Puntos_maximos)
                
            };
            var data = _databaseManager.ExecuteNoQuery(query, parameters);
            return Ok(new { message = "Cambios realizados"});
        }
    }
}