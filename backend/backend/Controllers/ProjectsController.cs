using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("all-projects")]
        public ActionResult<List<ProjectInformationResponseModel>> GetAllProjects()
        {
            try
            {
                return Ok(_projectService.getAllProjects());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-employee/{employeeId}")]
        public ActionResult<List<ProjectInformationResponseModel>> GetByEmployee(string employeeId)
        {
            try
            {
                return Ok(_projectService.getProjectsByAssignedEmployees(employeeId));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-invoice/{invoiceId}")]
        public ActionResult<ProjectInformationResponseModel> GetProjectByInvoice(string invoiceId)
        {
            try
            {
                return Ok(_projectService.getProjectByInvoice(invoiceId));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-projectNumber/{projectNumber}")]
        public ActionResult<ProjectInformationResponseModel> GetProjectByProjectNumber(string projectNumber)
        {
            try
            {
                return Ok(_projectService.getProjectByProjectNumber(projectNumber));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }



        [HttpPut("update-project")]
        public ActionResult UpdateProject([FromBody] ProjectInformationRequestModel project)
        {
            try
            {
                if (_projectService.updateProject(project))
                {
                    return Ok("Project Updated Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not save Update");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("create-project")]
        public ActionResult CreateProject([FromBody] ProjectInformationRequestModel project)
        {
           try
            {
                if (_projectService.createProject(project))
                {
                    return Ok("Project Created Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not save project");
                }
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
