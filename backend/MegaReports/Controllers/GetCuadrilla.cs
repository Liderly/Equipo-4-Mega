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

    public class Cuadrillas: ControllerBase
    {
        private readonly DatabaseManager _databaseManager;

        public Cuadrillas(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [HttpGet("Cuadrillas")]
        
        public IActionResult GetCuadrillas()
        {
            string query = "SELECT * From Cuadrillas;";

            var data = _databaseManager.ExecuteQuery(query);
            var DesData = new List<Dictionary<string, object>>();

            foreach (DataRow row in data.Rows) //Serializacion de los datos 
            {
                var cuadrillas = new Dictionary<string, object>();
                foreach (DataColumn column in data.Columns)
                {
                    cuadrillas.Add(column.ColumnName, row[column]);
                }
                DesData.Add(cuadrillas);
            }
            return Ok(DesData);
        }

        [HttpGet("Tecnicos-Cuadrilla")]
        public IActionResult GetTecnicosxCuadrilla([FromQuery] int CuadrillaId)
        {
            string query = @"SELECT * FROM Tecnicos WHERE CuadrillaId = @CuadrillaId; ";
            var parameters = new[]
            {
                new SqlParameter("@CuadrillaId", CuadrillaId)
            };
            var data = _databaseManager.ExecuteQuery(query, parameters);
            var DesData = new List<Dictionary<string, object>>();
            foreach (DataRow row in data.Rows)
            {
                var TCuadrilla = new Dictionary<string, object>();
                foreach (DataColumn column in data.Columns)
                {
                    TCuadrilla.Add(column.ColumnName, row[column]);
                }
                DesData.Add(TCuadrilla);
            }
            return Ok(DesData);
        }
    }

}