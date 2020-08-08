using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient.Memcached;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Clients : ControllerBase
    {
        private readonly IClientServices _clientService;

        public Clients(IClientServices clientServices)
        {
            _clientService = clientServices;
        }

        [HttpGet]
        public ActionResult<List<ClientRegistrationRequestModel>> GetAllClients()
        {
            try
            {
                return Ok(_clientService.GetAllClients());
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-registration/{companyRegistration}")]
        public ActionResult<ClientRegistrationRequestModel> GetClientId(string companyRegistration)
        {
            try
            {
                return Ok(_clientService.GetClient(companyRegistration));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("by-email/{email}")]
        public ActionResult<ClientRegistrationRequestModel> GetClientByEmail(string email)
        {
            try
            {
                return Ok(_clientService.GetClientByEmail(email));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update-client")]
        public ActionResult UpdateClient([FromBody] ClientRegistrationRequestModel client)
        {
            try
            {
                if (_clientService.UpdateClient(client))
                {
                    return Ok("Client updated successfully");
                }
                else
                {
                    return StatusCode(400, "Could not update client information");
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete-client/{companyRegistration}")]
        public ActionResult DeleteClient( string companyRegistration)
        {
            try
            {
                if(_clientService.DeleteClient(companyRegistration))
                {
                    return Ok(_clientService.DeleteClient(companyRegistration));
                }
                else
                {
                    return StatusCode(400, "Could not delete client");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
