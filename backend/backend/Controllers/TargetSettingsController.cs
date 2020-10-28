using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Exceptions;
using backend.Models.Request;
using backend.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetSettingsController : ControllerBase
    {
        private readonly ITargetSettingService _targetSettingService;

        public TargetSettingsController(ITargetSettingService targetSettingService)
        {
            _targetSettingService = targetSettingService;
        }

        [HttpGet("all")]
        public ActionResult<List<TargetSettingModel>> GetAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _targetSettingService.GetAll());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("by-id/{id}")]
        public ActionResult<TargetSettingModel> GetByTitle(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _targetSettingService.GetTargetSetting(id));
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("by-title/{title}")]
        public ActionResult<TargetSettingModel> GetByTitle(string title)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _targetSettingService.GetTargetSetting(title));
            }
            catch(McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost("create")]
        public ActionResult<TargetSettingModel> Create([FromBody] TargetSettingModel targetSetting)
        {
            try
            {
                if (_targetSettingService.CreateTargetSetting(targetSetting))
                {
                    return StatusCode(StatusCodes.Status200OK, "Created Successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not create target setting. Please verify your data");
                }
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("update")]
        public ActionResult<TargetSettingModel> Update([FromBody] TargetSettingModel targetSetting)
        {
            try
            {
                if (_targetSettingService.UpdateTargetSetting(targetSetting))
                {
                    return StatusCode(StatusCodes.Status200OK, "Updated Successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not update target setting. Please verify your data");
                }
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<TargetSettingModel> Delete(int id)
        {
            try
            {
                if (_targetSettingService.DeleteTargetSetting(id))
                {
                    return StatusCode(StatusCodes.Status200OK, "Deleted Successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Could not delete target setting. Please verify your data");
                }
            }
            catch (McpCustomException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }

    
}
