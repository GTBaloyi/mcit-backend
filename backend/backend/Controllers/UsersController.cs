using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }
       
        
        // GET: api/UserAccess
        [HttpGet("login")]
        public ActionResult<LoginResponseModel> Login([FromQuery] string username, [FromQuery] string  password)
        {

            try
            {
               LoginResponseModel serviceResponse = _userService.loginService(username, password);
               
                
                if(serviceResponse != null)
                {
                    return Ok(serviceResponse);
                }
               else
                {
                    return NotFound(new ErrorMessage(404, "Incorrect username / password"));
                }

            }
            catch(LoginException e)
            {
                if (e.Message == "Incorrect password")
                {
                    return StatusCode(401, new ErrorMessage(401, "Incorrect username / password"));
                } else
                {
                    if (e.Message.Contains("User's account is"))
                    {
                        return StatusCode(401, new ErrorMessage(401, e.Message));
                    } else
                    {
                        return StatusCode(401, new ErrorMessage(401, "Something went wrong"));
                    }
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
