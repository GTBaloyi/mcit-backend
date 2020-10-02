using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("by-invoice/{invoiceReference}")]
        public ActionResult<List<PaymentResponseModel>> GetByInvoice(string invoiceReference)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _paymentService.GetByInvoice(invoiceReference));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("by-company/{companyRegistration}")]
        public ActionResult<List<PaymentResponseModel>> GetByCompanyRegistration(string companyRegistration)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _paymentService.GetByCompanyRegistration(companyRegistration));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("by-date/{startDate}/{endDate}")]
        public ActionResult<List<PaymentResponseModel>> GetByDates(DateTime startDate, DateTime endDate)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _paymentService.GetByDates(startDate, endDate));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost("create")]
        public ActionResult<List<PaymentResponseModel>> GetByDates([FromBody] PaymentRequestModel payment)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _paymentService.CreatePayment(payment));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost("upload-pop")]
        public ActionResult UploadProofOfPayment([FromForm] FileModel proofOfPayment)
        {
            try
            {
                _paymentService.UploadProofOfPaymentAsync(proofOfPayment.FormFile);
                return StatusCode(StatusCodes.Status200OK, "Proof of payment uploaded successfully");
            }
            catch(McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("update")]
        public ActionResult UpdatePayment([FromBody] PaymentRequestModel proofOfPayment)
        {
            try
            {
                _paymentService.UpdatePayment(proofOfPayment);
                return StatusCode(StatusCodes.Status200OK, "Payment updated successfully");
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

        [HttpPut("delete")]
        public ActionResult DeletePayment([FromBody] PaymentRequestModel proofOfPayment)
        {
            try
            {
                _paymentService.DeletePayment(proofOfPayment);
                return StatusCode(StatusCodes.Status200OK, "Payment deleted successfully");
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
    }
}

