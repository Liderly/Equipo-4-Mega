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

    public class Tecnicos: ControllerBase{
        private readonly DatabaseManager _databaseManager;

        public Tecnicos(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [HttpGet("Tecnicos")]
        public IActionResult GetTecnicos()
        {
            string query = "SELECT * FROM tecnico;";
        
            var data = _databaseManager.ExecuteQuery(query);

            var DesData = new List<Dictionary<string, object>>();

            foreach (DataRow row in data.Rows) //Deserializacion de los datos 
            {
                var movie = new Dictionary<string, object>();
                foreach (DataColumn column in data.Columns)
                {
                    movie.Add(column.ColumnName, row[column]);
                }
                DesData.Add(movie);
            }
            return Ok(DesData);
        }
    }
}