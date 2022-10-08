using DomainModel.Models;
using FlightManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentRepository _documentRepository;
        public DocumentController(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public IActionResult GetDocuments()
        {
            try
            {
                return Ok(_documentRepository.GetDocuments());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{documentId:int}")]
        public IActionResult GetDocument(int documentId)
        {
            try
            {
                return Ok(_documentRepository.GetDocument(documentId));
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult AddDocument([FromBody] Document document)
        {
            if (document == null)
                return BadRequest();

            try
            {
                _documentRepository.InsertDocument(document);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult UpdateDocument([FromBody] Document document)
        {
            try
            {
                _documentRepository.UpdateDocument(document);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{documentId:int}")]
        public IActionResult DeleteDocument(int documentId)
        {
            try
            {
                _documentRepository.DeleteDocument(documentId);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
