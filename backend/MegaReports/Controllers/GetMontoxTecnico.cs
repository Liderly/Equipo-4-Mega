using System.Data;
using Microsoft.Data.SqlClient;
using MegaReports.data;
using Microsoft.AspNetCore.Mvc;
using MegaReports.Models;
using System.Reflection.Metadata;

namespace MegaReports.Controllers
{
    [ApiController]
    [Route("api/")]

    public class PuntosxTecnicos: ControllerBase
    {
        private readonly storedProcedure _storedProcedure;

        public PuntosxTecnicos(storedProcedure storedProcedure)
        {
            _storedProcedure = storedProcedure;
        }
        [HttpGet("MontoxTecnico")]
        public IActionResult executeStoredProcedurePuntosxTenico(int TecnicoId)
        {
            var results = _storedProcedure.ExecuteStoredProcedureMontoxTecnico(TecnicoId);
            return Ok(results);
        }
    }
}
