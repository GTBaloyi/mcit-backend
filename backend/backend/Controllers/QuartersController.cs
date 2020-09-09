using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.Request;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartersController : ControllerBase
    {
        private readonly IQuarterService _quarterService;

        public QuartersController(IQuarterService quarterService)
        {
            _quarterService = quarterService;
        }
        // GET: api/<ProjectTodos>
        [HttpGet("all")]
        public ActionResult<QuarterModel> GetAll()
        {
            try
            {
                return Ok(_quarterService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<ProjectTodos>/5
        [HttpGet("{id}")]
        public ActionResult<QuarterModel> GetById(int id)
        {
            try
            {
                return Ok(_quarterService.GetById(id));
            }
            catch(McpCustomException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<ProjectTodos>/5
        [HttpGet("by-quarter/{quarter}")]
        public ActionResult<QuarterModel> GetByQuarter(string quarter)
        {
            try
            {
                return Ok(_quarterService.GetByQuarter(quarter));
            }
            catch (McpCustomException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

       

        // POST api/<ProjectTodos>
        [HttpPost]
        public ActionResult Post([FromBody] QuarterModel quarter)
        {
            try
            {
                if (_quarterService.InsertQuarter(quarter))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(401, "Could not create quarter");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/<ProjectTodos>/5
        [HttpPut]
        public ActionResult Put([FromBody] QuarterModel quarter)
        {
            try
            {
                if (_quarterService.UpdateQuarter(quarter))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(401, "Could not update quarter");
                }
            }
            catch (McpCustomException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<ProjectTodos>/5
        [HttpDelete]
        public ActionResult Delete([FromBody] QuarterModel quarter)
        {
            try
            {
                if (_quarterService.DeleteQuarter(quarter))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(401, "Could not update quarter");
                }
            }
            catch (McpCustomException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
