using Microsoft.AspNetCore.Mvc;
using RhWebApi.Models;
using RhWebApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RhWebApi.Controllers
{
    [ApiController]
    //tag [controller] pega dinamicamente o nome da classe sem o sufixo controller, deixando facilitado a manutenção do codigo
    [Route("api/[controller]")]
    public class CandidateTechnologyController : ControllerBase
    {
        private readonly ICandidateTechnologyService _service;

        public CandidateTechnologyController(ICandidateTechnologyService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all Candidates Technologies", Description = "Get all Candidates Technologies.")]
        [SwaggerResponse(200, "Returns the list of Candidates Technologies", typeof(IEnumerable<CandidateTechnology>))]
        public ActionResult<IEnumerable<CandidateTechnology>> GetAll()
        {
            var CandidatesTechnologies = _service.GetAll();
            return Ok(CandidatesTechnologies);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get CandidateTechnology by ID", Description = "Get a specific CandidateTechnology by its ID.")]
        [SwaggerResponse(200, "Returns the CandidateTechnology", typeof(CandidateTechnology))]
        [SwaggerResponse(404, "If the CandidateTechnology with the specified ID does not exist")]
        public ActionResult<CandidateTechnology> GetById(int id)
        {
            var CandidateTechnology = _service.GetById(id);
            if (CandidateTechnology == null)
            {
                return NotFound();
            }
            return Ok(CandidateTechnology);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new CandidateTechnology", Description = "Create a new CandidateTechnology.")]
        [SwaggerResponse(201, "Returns the newly created CandidateTechnology", typeof(CandidateTechnology))]
        public ActionResult<CandidateTechnology> Create(CandidateTechnology CandidateTechnology)
        {
            _service.Add(CandidateTechnology);
            return CreatedAtAction(nameof(GetById), new { id = CandidateTechnology.Id }, CandidateTechnology);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing CandidateTechnology", Description = "Update an existing CandidateTechnology.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(400, "If the ID in the URL does not match the ID in the request body")]
        public IActionResult Update(int id, CandidateTechnology CandidateTechnology)
        {
            if (id != CandidateTechnology.Id)
            {
                return BadRequest();
            }
            _service.Update(CandidateTechnology);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a CandidateTechnology", Description = "Delete a CandidateTechnology by its ID.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(404, "If the CandidateTechnology with the specified ID does not exist")]
        public IActionResult Delete(int id)
        {
            var CandidateTechnology = _service.GetById(id);
            if (CandidateTechnology == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
        }
    }

}
