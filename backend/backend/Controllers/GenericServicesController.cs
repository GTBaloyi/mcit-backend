using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using backend.Services.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.DataAccess.Database.Repositories.Contracts;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericServicesController : ControllerBase
    {
        private readonly CommonServices commonService = new CommonServices();
        private readonly IEmailTemplateRepository emailTemplate;
        public GenericServicesController(IEmailTemplateRepository emailTemplate)
        {
            this.emailTemplate = emailTemplate;
        }

        [HttpPost("email-attachment")]
        public async Task<ActionResult> EmailWithAttachment([FromQuery] string reciepentAddress, [FromQuery] string subject, [FromQuery] string body)
        {

            try
            {
                if(reciepentAddress != null && subject !=null && body !=null )
                {
                    try
                    {
                        commonService.SendEmailWithAttachment(subject, this.emailTemplate.GetByType("GenericEmail").code.Replace("{body}", body), reciepentAddress, "");

                    }
                    catch(Exception e)
                    {
                       
                        return StatusCode(StatusCodes.Status403Forbidden, e.Message);
                       
                    }

                    
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Some fields are null. Enter all fields");
                }
                
            }
            catch ( Exception e)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }

    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
