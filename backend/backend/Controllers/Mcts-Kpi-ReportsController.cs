using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.General;
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


        [HttpGet("delivered-inTime-report")]
        public ActionResult<List<PerformanceIndicatorModel>> DeliveredInTimeReport()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _mctsKpiReports.GetProjectsDeliveredInTime());
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        

        [HttpGet("customer-satisfaction")]
        public ActionResult<List<PerformanceIndicatorModel>> CustomerSatisfactionReport()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _mctsKpiReports.GetCustomerSatisfaction());
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("FocusArea-Final-Projects")]
        public ActionResult<List<ProjectsEntryModel>> GetFocusAreaFinancials()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _mctsKpiReports.GetFocusAreaFinancials());
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("general-quotation")]
        public ActionResult<GeneralQuotationReport> GeneralQuotationReport()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _mctsKpiReports.GetGeneralQuotationReport());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("general-projects")]
        public ActionResult<GeneralProjectReportsModel> GeneralProjectsReport()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _mctsKpiReports.GeneralProjectReports());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
