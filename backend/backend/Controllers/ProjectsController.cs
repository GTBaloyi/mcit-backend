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

        [HttpGet("summary/{projectLeaderId}")]
        public ActionResult<List<ProjectSummaryModel>> GetProjectSummaryByLeader(string projectLeaderId)
        {
            try
            {
                return Ok(_projectService.getAllProjectSummaryByLeader(projectLeaderId));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("summary")]
        public ActionResult<List<ProjectSummaryModel>> GetProjectSummary()
        {
            try
            {
                return Ok(_projectService.getAllProjectSummary());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-company/{companyRegistration}")]
        public ActionResult<List<ProjectInformationResponseModel>> GetByCompany(string companyRegistration)
        {
            try
            {
                return Ok(_projectService.getProjects(companyRegistration));
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
                ProjectInformationResponseModel data = _projectService.getProjectByInvoice(invoiceId);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound("Project with invoice "+invoiceId+ " not found" );
                }

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
                ProjectInformationResponseModel result = _projectService.getProjectByProjectNumber(projectNumber);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("Project with project number " + projectNumber + " not found");
                }
            }
            catch(Exception)
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
            catch(McpCustomException e)
            {
                return StatusCode(404, e.Message);
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
                    return StatusCode(200, "Project Created Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not save project");
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

        [HttpDelete("{projectNumber}")]
        public ActionResult Delete(string projectNumber)
        {
            try
            {
                if (_projectService.deleteProject(projectNumber))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified);
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
