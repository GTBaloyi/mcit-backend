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
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            return null;
        }

        [HttpGet("{employeeNumber}")]
        public ActionResult GetEmployeeByEmployeeNumber(string employeeNumber)
        {
            return null;
        }

        [HttpGet("update-employee")]
        public ActionResult UpdateEmployee([FromBody] string employee)
        {
            return null;
        }

        [HttpGet("delete-employee")]
        public ActionResult DeleteEmployee([FromBody] string employee)
        {
            return null;
        }
    }
}
