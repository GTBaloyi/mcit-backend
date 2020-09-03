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
        public async Task<ActionResult> EmailWithAttachment([FromQuery] string reciepentAddress, [FromQuery] string subject, [FromQuery] string body, [FromForm] FileModel file)
        {

            try
            {
                if(reciepentAddress != null && subject !=null && body !=null && file.FileName !=null && file.FormFile!=null )
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdf", file.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.FormFile.CopyTo(stream);
                    }

                    try
                    {
                        commonService.SendEmailWithAttachment(subject, this.emailTemplate.GetByType("GenericEmail").code.Replace("{body}", body), reciepentAddress, path);

                    }
                    catch(Exception)
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, "There was a problem sending an email. Please make sure you submit a valid email.");
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Some fields are null. Enter all fields");
                }
                
            }
            catch ( Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
