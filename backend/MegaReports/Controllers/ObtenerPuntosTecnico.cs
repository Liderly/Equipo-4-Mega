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

        [HttpGet("PuntosxTecnico")]
        public IActionResult executeStoredProcedurePuntosxTenico(int param)
        {
            var results = _storedProcedure.executeStoredProcedurePuntosxTenico(param);
            return Ok(results);
        }
    }
}
