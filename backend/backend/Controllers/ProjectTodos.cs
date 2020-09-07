using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.Request;
using backend.Models.Response;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTodos : ControllerBase
    {
        private readonly IProjectTodoService _projectTodoService;

        public ProjectTodos(IProjectTodoService projectTodoService)
        {
            _projectTodoService = projectTodoService;
        }
        // GET: api/<ProjectTodos>
        [HttpGet("all")]
        public ActionResult<ProjectTodoResponseModel> GetAll()
        {
            try
            {
                return Ok(_projectTodoService.getAllProjectTodos());
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<ProjectTodos>/5
        [HttpGet("dateRange")]
        public ActionResult<ProjectTodoResponseModel> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                return Ok(_projectTodoService.getProjectTodoByDateRange(startDate, endDate));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<ProjectTodos>/5
        [HttpGet("focusArea/{focusArea}")]
        public ActionResult<ProjectTodoResponseModel> GetByFocusArea(string focusArea)
        {
            try
            {
                return Ok(_projectTodoService.getProjectTodoByFocusArea(focusArea));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<ProjectTodos>/5
        [HttpGet("item/{item}")]
        public ActionResult<ProjectTodoResponseModel> GetByItem(string item)
        {
            try
            {
                return Ok(_projectTodoService.getProjectTodoByItem(item));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/<ProjectTodos>/5
        [HttpGet("projectNumber/{projectNumber}")]
        public ActionResult<ProjectTodoResponseModel> GetByProjectNumber(string projectNumber)
        {
            try
            {
                return Ok(_projectTodoService.getProjectTodoByProjectNumber(projectNumber));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<ProjectTodos>
        [HttpPost]
        public ActionResult Post([FromBody] ProjectTodosRequestModel projectTodo)
        {
            try
            {
                if(_projectTodoService.createProjectTodo(projectTodo))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(401,"Could not create project todo");
                }
            }
            catch( Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/<ProjectTodos>/5
        [HttpPut]
        public ActionResult Put([FromBody] ProjectTodosRequestModel projectTodo)
        {
            try
            {
                if (_projectTodoService.updateProjectTodo(projectTodo))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(401, "Could not create project todo");
                }
            }
            catch(McpCustomException e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE api/<ProjectTodos>/5
        [HttpDelete("delete")]
        public ActionResult Delete([FromBody] ProjectTodosRequestModel projectTodo)
        {
            try
            {
                if (_projectTodoService.deleteProject(projectTodo))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(401, "Could not delete project todo");
                }
            }
            catch (McpCustomException e)
            {
                return StatusCode(401, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
