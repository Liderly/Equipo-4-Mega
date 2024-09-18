using System.Data;
using Microsoft.Data.SqlClient;
using MegaReports.data;
using Microsoft.AspNetCore.Mvc;
using MegaReports.Models;
using ServerAsp.Data;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/")]

    public class OrdenTrabajo: ControllerBase{
        private readonly DatabaseManager _databaseManager;

        public OrdenTrabajo(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [HttpGet("Ordenes")]
        public IActionResult GetOrdenesTrabajo([FromQuery] int id)
        {
            string query = @"SELECT 
                            ot.suscriptor_id,
                            t.nombre AS nombre_tecnico,
                            t.apellidos AS apellidos_tecnico,
                            c.nombre AS cuadrilla_nombre,
                            ot.fecha_inicio,
                            ot.fecha_fin,
                            ot.estatus
                        FROM 
                            Orden_de_trabajo ot
                        JOIN 
                            Tecnico t ON ot.tecnico_id = t.id
                        JOIN 
                            Trabajo tr ON ot.trabajo_id = tr.id
                        JOIN 
                            Cuadrilla c ON t.cuadrilla_id = c.id
                        WHERE t.id = 1;";
        
            var parameters = new[]
            {
                new SqlParameter("@id", id)
            };

            var data = _databaseManager.ExecuteQuery(query, parameters);
            var DesData = new List<Dictionary<string, object>>();
            foreach (DataRow row in data.Rows)
            {
                var favorite = new Dictionary<string, object>();
                foreach (DataColumn column in data.Columns)
                {
                    favorite.Add(column.ColumnName, row[column]);
                }
                DesData.Add(favorite);
            }
            return Ok(DesData);
        }

    }
}