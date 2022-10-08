using DomainModel.Models;
using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _roleRepository;
        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                return Ok(_roleRepository.GetRoles());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{roleId:int}")]
        public IActionResult GetRole(int roleId)
        {
            try
            {
                return Ok(_roleRepository.GetRole(roleId));
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddRole([FromBody] Role role)
        {
            if (role == null)
                return BadRequest();

            try
            {
                _roleRepository.InsertRole(role);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateRole([FromBody] Role role)
        {
            try
            {
                _roleRepository.UpdateRole(role);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{roleId:int}")]
        public IActionResult DeleteRole(int roleId)
        {
            try
            {
                _roleRepository.DeleteRole(roleId);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
