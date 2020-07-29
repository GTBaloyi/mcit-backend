using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationService _quotationService;
        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [HttpPost("create-quote")]//saves a new quotaion
        public ActionResult CreateEnquiry([FromBody] QuotationModel quote)
        {
            try
            {
                if (_quotationService.NewQuotation(quote))
                {
                    return StatusCode(200, "Quotation Captured");
                }
                else
                {
                    return StatusCode(409, "Quotation not saved");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPut("update-quote")]//updates an existing Quotation
        public ActionResult<QuotationResponseModel> UpdateQuotation([FromBody] QuotationModel model)
        {
            try
            {

                QuotationResponseModel response = _quotationService.Update(model);
                if (response != null)
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(407, "Quotation not updated");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpGet("quote/{id}")]
        public ActionResult<QuotationResponseModel> GetQuoteById(int id)
        {
            try
            {
                QuotationResponseModel response = _quotationService.GetById(id);
                if (response != null)
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(404, "Quotation not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }


        }

        [HttpGet("quotes/{email}")]
        public ActionResult<List<QuotationResponseModel>> GetQuoteByCompany(string email)
        {
            try
            {
                List<QuotationResponseModel> response = _quotationService.GetQuotationByCompany(email);
                return StatusCode(200, response);
              
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }


        }

        [HttpGet("quotes")]
        public ActionResult<List<QuotationResponseModel>> GetAllEnquiries()
        {
            try
            {
                List<QuotationResponseModel> quotes = _quotationService.GetAll();
                if (quotes == null)
                {
                    return StatusCode(203, "No Quotations found");
                }
                else
                {
                    return StatusCode(200, quotes);
                }
            }

            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }
    }
}