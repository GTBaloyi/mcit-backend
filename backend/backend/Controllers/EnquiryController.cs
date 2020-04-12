using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Request;
using backend.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {

        [HttpPost]
        public ActionResult<EnquiryResponseModel> CreateEnquiry([FromBody] EnquiryRequestModel enquiryRequest)
        {
            return Ok();
        }


    }
}