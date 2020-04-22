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
        public ActionResult<EnquiryResponseModel> CreateEnquiry([FromBody] EnquiryRequestModel model)
        {
            try
            {
                EnquiryResponseModel response = _enquiryService.NewEnquiry(model);
                return response;
            }
            
            catch (Exception)
            {
                return new EnquiryResponseModel(003, "Internal Server Error");
            }
        }


        [HttpPut("Update")]//updates an existing enquiry
        public ActionResult<EnquiryResponseModel> UpdateEnquiry([FromBody] EnquiryRequestModel model)
        {
            try
            {
                EnquiryResponseModel response = _enquiryService.Update(model);
                return response;
            }

            catch (Exception)
            {
                return new EnquiryResponseModel(004, "Could not Update Entry, internal server error");
            }
           
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<EnquiryRequestModel> GetEnquiry([FromBody] int id)
        {
            try
            {
                EnquiryRequestModel response = _enquiryService.GetById(id);
                return response;
                if (response != null)
                {
                    return response;
                }
                else
                {
                    return NotFound("Enquiry does not exist / has been deleted");
                }
            }

            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }

            
        }

        [HttpGet("GetAll")]
        public ActionResult <List<EnquiryRequestModel>> GetAllEnquiries()
        {
            try
            {
                List<EnquiryRequestModel> enquiries = _enquiryService.GetAll();
                return enquiries;
            }

            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }

    }
}