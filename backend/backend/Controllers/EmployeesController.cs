using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataAccess.Database.Entities;
using backend.Models.Request;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeesController(IEmployeeServices employeeServices)
        {
            _employeeService = employeeServices;
        }

        [HttpGet]
        public ActionResult<List<EmployeeResponseModel>> GetAllEmployees()
        {
            try
            {
                return Ok(_employeeService.getAllEmployees());
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{employeeNumber}")]
        public ActionResult<EmployeeResponseModel> GetEmployeeByEmployeeNumber(string employeeNumber)
        {
            try
            {
                EmployeeResponseModel response = _employeeService.getEmployeeByEmployeeNumber(employeeNumber);
                if(response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update-employee")]
        public ActionResult UpdateEmployee([FromBody] EmployeeResponseModel employee)
        {
            try
            {
                _employeeService.updateEmployee(employee);
                 return Ok();
                
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete-employee/{employeeNumber}")]
        public ActionResult DeleteEmployee( string employeeNumber)
        {
            try
            {
                if (_employeeService.deleteEmployee(employeeNumber))
                {
                    return Ok();
                }
                else
                {
                    return NotFound("Could not find employee with id : " + employeeNumber);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("create-employee")]
        public ActionResult CreateEmployee(EmployeeRequestModel employee)
        {
            try
            {
                if(_employeeService.createEmployee(employee))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(400, "Something went wrong while trying to create employee");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("employee-position")]
        public ActionResult<List<EmployeesPositionEntity>> GetAllEmployeePosition()
        {
            try
            {
                return _employeeService.GetEmployeesPosition();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
