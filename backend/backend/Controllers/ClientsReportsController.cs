using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsReportsController : ControllerBase
    {
        private readonly IClientsReportsService _clientsReportsService;
        public ClientsReportsController(IClientsReportsService clientsReportsService)
        {
            _clientsReportsService = clientsReportsService;
        }

        [HttpGet("invoice-summary/{companyRegistration}")]
        public ActionResult<ClientInvoiceSummary> GetClientInvoiceReport(string companyRegistration)
        {
            try
            {
               return StatusCode(StatusCodes.Status200OK,_clientsReportsService.clientInvoiceSummary(companyRegistration));
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }
        }

        [HttpGet("invoice-summary")]
        public ActionResult<ClientInvoiceSummary> GetAllInvoiceReportSummary()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _clientsReportsService.clientInvoiceSummaries());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }
        }
    }
}
