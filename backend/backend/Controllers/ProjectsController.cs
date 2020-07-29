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
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllProjects()
        {
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult GetProjectById(int id)
        {
            return null;
        }

        [HttpPut("update-project")]
        public ActionResult UpdateProject([FromBody] string project)
        {
            return null;
        }

        [HttpPut("create-project")]
        public ActionResult CreateProject([FromBody] string project)
        {
            return null;
        }

        [HttpDelete("delete-project")]
        public ActionResult DeleteProject([FromBody] string employee)
        {
            return null;
        }
    }
}
