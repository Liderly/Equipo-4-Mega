using System.Data;
using Microsoft.Data.SqlClient;
using MegaReports.data;
using Microsoft.AspNetCore.Mvc;
using MegaReports.Models;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/")]

    public class OrdenTrabajo : ControllerBase
    {
        private readonly DatabaseManager _databaseManager;

        public OrdenTrabajo(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [HttpGet("Ordenes")]
        public IActionResult GetOrdenesTrabajo([FromQuery] int id)
        {
            string query = @"SELECT OT.Id AS IdOrdenTrabajo, 
                                OT.Tiempo_registro AS TiempoRegistroOrdenTrabajo,
                                OT.Tiempo_finalizado AS TiempoFinalizadoOrdenTrabajo,
                                OT.Estatus AS EstatusOrdenTrabajo,
                                T.Nombre AS NombreTrabajo,
                                T.Descripcion AS DescripcionTrabajo,
                                C.Nombre AS NombreCuadrilla,  
                                S.Nombres AS NombresSuscriptior,
                                S.Apellido_p AS ApellidoPSuscriptior,
                                S.Apellido_m AS ApellidoMSuscriptior,
                                S.Numero_interior AS NumeroInteroprSuscriptor,
                                S.Numero_exterior AS NumeroExteriorSuscriptor,
                                S.Codigo_postal AS CodigoPostalSuscriptor,
                                S.Colonia AS ColoniaSuscriptor,
                                S.Telefono AS TelefonoSuscriptor,
								TE.Id AS IdTecnico,
								TE.Nombres AS Nombres,
								TE.Apellido_p AS ApellidoPTecnico,
								TE.Apellido_m AS ApellidoMTecnico,
								TE.Numero_empleado AS NumeroEmpleado,
								TE.CuadrillaId AS CuadrillaIdTecnico
                            FROM Ordenes_trabajo OT
                            JOIN Tecnicos TE ON TE.CuadrillaId = OT.CuadrillaId
                            JOIN Trabajos T ON T.Id = OT.TrabajoId
                            JOIN Cuadrillas C ON C.Id = OT.CuadrillaId 
                            JOIN Suscriptores S ON S.Id = OT.SuscriptorId 
                            WHERE TE.Id = @Id";

            var parameters = new[]
            {
                new SqlParameter("@Id", id)
            };

            var data = _databaseManager.ExecuteQuery(query, parameters);
            var DesData = new List<Dictionary<string, object>>();
            foreach (DataRow row in data.Rows)
            {
                var orden = new Dictionary<string, object>();
                foreach (DataColumn column in data.Columns)
                {
                    orden.Add(column.ColumnName, row[column]);
                }
                DesData.Add(orden);
            }
            return Ok(DesData);
        }

    }
}