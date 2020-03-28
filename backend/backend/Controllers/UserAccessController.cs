using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        private readonly IUsersService _userService;
        public UserAccessController(IUsersService userService)
        {
            _userService = userService;
        }
       
        
        // GET: api/UserAccess
        [HttpGet]
        public ActionResult Login([FromQuery] string username, [FromQuery] string  password)
        {

            try
            {
               UsersModel user = _userService.loginService(username, password);
               if(user != null)
                {
                    if(user.retry >= 3)
                    {
                        return StatusCode(401, new ErrorMessage(401, "User exceeded number of login tries"));
                    }
                    if (user.userStatus != 1)
                    {
                        return StatusCode(401, new ErrorMessage(401, "User is not authorized to use this application, Contact the administrator to resolve issue."));
                    }
                    return Ok(user);
                }
               else
                {
                    return NotFound(new ErrorMessage(404, "Incorrect username / password"));
                }

            }
            catch(Exception)
            {
                return StatusCode(500, new ErrorMessage(500, "Internal Server Error"));
            }
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
