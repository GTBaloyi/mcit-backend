using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectProgressController : ControllerBase
    {
        private readonly IProjectProgressService _projectProgressService;

        public ProjectProgressController(IProjectProgressService projectService)
        {
            _projectProgressService = projectService;
        }

        [HttpGet("all-projects")]
        public ActionResult<List<ProjectProgressResponseModel>> GetAllProjectProgress()
        {
            try
            {
                return Ok(_projectProgressService.getAllProjectProgress());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-quarter/{quarter}")]
        public ActionResult<List<ProjectProgressResponseModel>> GetProjectProgressByQuarter(string quarter)
        {
            try
            {
                return Ok(_projectProgressService.getProjectProgressByQuarter(quarter));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-projectNumber/{projectNumber}")]
        public ActionResult<List<ProjectProgressResponseModel>> GetProjectProgressByProjectNumber(string projectNumber)
        {
            try
            {
                return Ok(_projectProgressService.getProjectProgressByProjectNumber(projectNumber));
            }
            catch(McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPut("update")]
        public ActionResult UpdateProjectProgress([FromBody] ProjectProgressRequestModel projectProgress)
        {
            try
            {
                if (_projectProgressService.updateProjectProgress(projectProgress))
                {
                    return Ok("Project progress Updated Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not Update");
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

        [HttpPost("create")]
        public ActionResult CreateProjectProgress([FromBody] ProjectProgressRequestModel projectProgress)
        {
            try
            {
                if (_projectProgressService.createProjectProgress(projectProgress))
                {
                    return Ok("Project progress Created Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not save project progress");
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

        
        [HttpDelete("delete/{projectNumber}")]
        public ActionResult DeleteProjectProgres(string projectNumber)
        {
            try
            {
                if (_projectProgressService.deleteProject(projectNumber))
                {
                    return Ok("Project Created Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not delete project progress");
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
