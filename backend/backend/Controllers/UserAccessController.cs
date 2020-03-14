using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        
        // GET: api/UserAccess
        [HttpGet]
        public ActionResult Login([FromQuery] string username, [FromQuery] string  password)
        {

            return Ok();
        }

        // GET: api/UserAccess/5
        [HttpGet("{username}")]
        public ActionResult Logout()
        {
            
            return Ok();

        }

        // POST: api/UserAccess
        [HttpPost]
        public void RegisterEmployee([FromBody] string value)
        {
        }

        // PUT: api/UserAccess/5
        [HttpPut("{id}")]
        public void RegisterCustomer(int id, [FromBody] string value)
        {
        }

       
    }
}
