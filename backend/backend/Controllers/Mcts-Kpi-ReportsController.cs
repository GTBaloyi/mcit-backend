using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Reports;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mcts_Kpi_ReportsController : ControllerBase
    {
        private readonly IMctsKpiReports _mctsKpiReports;
        public Mcts_Kpi_ReportsController(IMctsKpiReports mctsKpiReports)
        {
            _mctsKpiReports = mctsKpiReports;
        }

        [HttpGet("mcts-kpi-summary-tiles")]
        public ActionResult<MctsKpiSummaryTile> mctsKpiSummaryTile()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK,_mctsKpiReports.GetSummaryTileInfo());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
