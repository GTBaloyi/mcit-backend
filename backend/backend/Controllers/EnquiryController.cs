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
        public ActionResult CreateEnquiry([FromBody] EnquiryRequestModel enquiry)
        {
            try
            {
                if (_enquiryService.NewEnquiry(enquiry))
                {
                    return StatusCode(200,"Enquiry Captured");
                }
                else
                {
                    return StatusCode(409, "Enquiry not saved");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPut("Update")]//updates an existing enquiry
        public ActionResult<EnquiryResponseModel> UpdateEnquiry([FromBody] EnquiryRequestModel model)
        {
            try
            {

                EnquiryResponseModel response = _enquiryService.Update(model);
                if(response != null)
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(407, "Enquiry not updated");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<EnquiryResponseModel> GetEnquiry(int id)
        {
            try
            {
                EnquiryResponseModel response = _enquiryService.GetById(id);
                if(response !=null)
                {
                    return StatusCode(200, response);
                } else
                {
                    return StatusCode(404, "Enquiry not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            } 
        }

        [HttpGet("GetAll")]
        public ActionResult <List<EnquiryResponseModel>> GetAllEnquiries()
        {
            try
            {
                List<EnquiryResponseModel> enquiries = _enquiryService.GetAll();
                if(enquiries == null)
                {
                    return StatusCode(203, "No enquiries found");
                } else
                {
                    return StatusCode(200,enquiries);
                }
            }

            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }

    }
}