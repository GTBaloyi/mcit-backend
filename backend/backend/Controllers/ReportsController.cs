using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.General;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IReportsServices reportsServices;

        public ReportsController(IReportsServices reportsServices)
        {
            this.reportsServices = reportsServices;
        }

        [HttpGet("clients-general-report")]
        public ActionResult<ClientsGeneralReportsModel> GetAllClientsGeneralReport()
        {
            
            try
            {
                return Ok(reportsServices.GetClientsGeneralReports());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("invoice-general-report")]
        public ActionResult<ClientsGeneralReportsModel> GetAllInvoiceGeneralReport()
        {

            try
            {
                return Ok(reportsServices.GetInvoiceGeneralReports());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
