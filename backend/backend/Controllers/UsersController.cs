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
            catch(McpCustomException e)
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

        [HttpPost("client-registration")]
        public ActionResult<ClientRegistrationResponseModel> ClientRegistration([FromBody] ClientRegistrationRequestModel request)
        {
           try
            {
                return Ok(_userService.registerService(request));
            }
            catch (McpCustomException ex)
            {
                if(ex.Message == "Could not save new user")
                {
                    return Unauthorized("Registration process failed. Could not create a new client user");
                } else
                {
                    if(ex.Message == "Could not save company representative")
                    {
                        return Unauthorized( "Registration process failed. Could not create a company representative");
                    } else
                    {
                        if (ex.Message == "Company not saved")
                        {
                            return Unauthorized( "Registration process failed. Could not create a company");
                        } else
                        {
                            return Unauthorized("Registration process failed. Company Submitted is not registered.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }       
    }
}
