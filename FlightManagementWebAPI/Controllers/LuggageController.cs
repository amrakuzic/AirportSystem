using DomainModel.Models;
using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuggageController : ControllerBase
    {
        private readonly LuggageRepository _luggageRepository;
        public LuggageController(LuggageRepository luggageRepository)
        {
            _luggageRepository = luggageRepository;
        }

        [HttpGet]
        public IActionResult GetLuggages()
        {
            try
            {
                return Ok(_luggageRepository.GetLuggages());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{luggageId:int}")]
        public IActionResult GetLuggage(int luggageId)
        {
            try
            {
                return Ok(_luggageRepository.GetLuggage(luggageId));
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddLuggage([FromBody] Luggage luggage)
        {
            if (luggage == null)
                return BadRequest();

            try
            {
                _luggageRepository.InsertLuggage(luggage);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateLuggage([FromBody] Luggage luggage)
        {
            try
            {
                _luggageRepository.UpdateLuggage(luggage);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{luggageId:int}")]
        public IActionResult DeleteLuggage(int luggageId)
        {
            try
            {
                _luggageRepository.DeleteLuggage(luggageId);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
