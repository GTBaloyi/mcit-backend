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
        public ActionResult CreateInvoice([FromBody] InvoiceRequestModel invoice)
        {
            try
            {
                if (_invoiceService.GenerateInvoice(invoice))
                {
                    return StatusCode(200, "Invoice Captured");
                }
                else
                {
                    return StatusCode(409, "Invoice not saved");
                }
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

        [HttpGet("invoice/{id}")]
        public ActionResult<InvoiceResponseModel> GetInvoice(int id)
        {
            try
            {
                InvoiceResponseModel response = _invoiceService.GetById(id);
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