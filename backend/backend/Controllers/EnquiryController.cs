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
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiryService _enquiryService;
        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        [HttpPost("NewEnquiry")]//saves a new enquiry
        public ActionResult<EnquiryResponseModel> CreateEnquiry([FromQuery]int id, [FromQuery] int focusAreaId, [FromQuery] DateTime enquiryDate, [FromQuery] string quarter, [FromQuery] string company, [FromQuery] string companyRegistrationNumber, [FromQuery] string description, [FromQuery] int serviceTechId, [FromQuery] int socioEconomicImpactId, [FromQuery] int productExpectationid, [FromQuery] double projectBudget, [FromQuery] DateTime expectedCompletion)
        {
            EnquiryResponseModel model = _enquiryService.NewEnquiry(id, focusAreaId, enquiryDate, quarter, company, companyRegistrationNumber, description, serviceTechId, socioEconomicImpactId, productExpectationid, projectBudget, expectedCompletion);
            return model;
        }


        [HttpPut("Update")]//updates an existing enquiry
        public ActionResult<EnquiryResponseModel> UpdateEnquiry([FromBody] EnquiryRequestModel model)
        {
            EnquiryResponseModel response = _enquiryService.Update(model);
            return response;
        }

        [HttpGet("GetById")]
        public ActionResult<EnquiryRequestModel> GetEnquiry([FromBody] int id)
        {
            EnquiryRequestModel response = _enquiryService.GetById(id);
            return response;
        }

        [HttpGet("GetAllEnquiries")]
        public ActionResult <List<EnquiryRequestModel>> GetAllEnquiries()
        {
            List<EnquiryRequestModel> enquiries = _enquiryService.GetAll();
            return enquiries;
        }

    }
}