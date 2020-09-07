using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectExpenditureController : ControllerBase
    {
        private readonly IProjectExpenditureService _projectExpenditureService;

        public ProjectExpenditureController(IProjectExpenditureService projectExpenditureService)
        {
            _projectExpenditureService = projectExpenditureService;
        }

        [HttpGet("all-projectExpenditures")]
        public ActionResult<List<ProjectExpenditureResponseModel>> GetAllProjectExpenditure()
        {
            try
            {
                return Ok(_projectExpenditureService.getAllProjectExpenditures());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-focusArea/{focusArea}")]
        public ActionResult<List<ProjectExpenditureResponseModel>> GetProjectExpenditureByFocusArea(string focusArea)
        {
            try
            {
                return Ok(_projectExpenditureService.getProjectExpenditureByFocusArea(focusArea));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("by-item/{item}")]
        public ActionResult<List<ProjectExpenditureResponseModel>> GetProjectExpenditureByItem(string item)
        {
            try
            {
                return Ok(_projectExpenditureService.getProjectExpenditureByItem(item));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("by-projectNumber/{projectNumber}")]
        public ActionResult<ProjectExpenditureResponseModel> GetProjectExpenditureByProjectNumber(string projectNumber)
        {
            try
            {
                return Ok(_projectExpenditureService.getProjectExpenditureByProjectNumber(projectNumber));
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
        public ActionResult UpdateProjectExpenditure([FromBody] ProjectExpenditureRequestModel projectExpenditure)
        {
            try
            {
                if (_projectExpenditureService.updateProjectExpenditure(projectExpenditure))
                {
                    return Ok("Project Expenditure Updated Successfully");
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
        public ActionResult CreateProjectExpenditure([FromBody] ProjectExpenditureRequestModel projectExpenditure)
        {
            try
            {
                if (_projectExpenditureService.createProjectExpediture(projectExpenditure))
                {
                    return Ok("Project Expenditure Created Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not save project Expenditure");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpDelete("delete")]
        public ActionResult DeleteProjectProgres([FromBody] ProjectExpenditureRequestModel projectExpenditure)
        {
            try
            {
                if (_projectExpenditureService.deleteProject(projectExpenditure))
                {
                    return Ok("Project Expenditure Created Successfully");
                }
                else
                {
                    return StatusCode(400, "Could not delete project Expenditure");
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
