using System;
using System.Collections.Generic;
using System.Linq;
using backend.Services.Contracts;
using backend.DataAccess;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("generate-invoice")]//generate and saves a new invoice
        public ActionResult<InvoiceResponseModel> CreateInvoice([FromBody] InvoiceRequestModel invoice)
        {
            try
            {
                InvoiceResponseModel result = _invoiceService.GenerateInvoice(invoice);
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(409, "Invoice not saved");
                }
            }
            catch(McpCustomException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }



        [HttpPut("update-invoice")]//updates an existing invoice
        public ActionResult<InvoiceResponseModel> UpdateInvoice([FromBody] InvoiceRequestModel model)
        {
            try
            {

                InvoiceResponseModel response = _invoiceService.Update(model);
                if (response != null)
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(407, "Invoice not updated");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpGet("invoice/{companyRegistration}")]
        public ActionResult<List<InvoiceResponseModel>> GetInvoice(string companyRegistration)
        {
            try
            {
                List<InvoiceResponseModel> response = _invoiceService.GetById(companyRegistration);
                if (response != null)
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(404, "Invoice not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }


        }

        [HttpGet("invoice/by-reference/{invoiceReference}")]
        public ActionResult<InvoiceResponseModel> GetInvoiceByReference(string invoiceReference)
        {
            try
            {
                return _invoiceService.GetByInvoiceReference(invoiceReference);
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }


        }

        [HttpGet("invoice")]
        public ActionResult<List<InvoiceResponseModel>> GetAllInvoices()
        {
            try
            {
                List<InvoiceResponseModel> invoices = _invoiceService.GetAll();
                if (invoices == null)
                {
                    return StatusCode(203, "No invoices found");
                }
                else
                {
                    return StatusCode(200, invoices);
                }
            }

            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

    }
}