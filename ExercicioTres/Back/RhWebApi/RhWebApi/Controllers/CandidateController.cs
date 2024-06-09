using Microsoft.AspNetCore.Mvc;
using RhWebApi.Models;
using RhWebApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RhWebApi.Controllers
{
    [ApiController]
    //tag [controller] pega dinamicamente o nome da classe sem o sufixo controller, deixando facilitado a manutenção do codigo
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all Candidates", Description = "Get all Candidates.")]
        [SwaggerResponse(200, "Returns the list of Candidates", typeof(IEnumerable<Candidate>))]
        public ActionResult<IEnumerable<Candidate>> GetAll()
        {
            var Candidates = _service.GetAll();
            return Ok(Candidates);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Candidate by ID", Description = "Get a specific Candidate by its ID.")]
        [SwaggerResponse(200, "Returns the Candidate", typeof(Candidate))]
        [SwaggerResponse(404, "If the Candidate with the specified ID does not exist")]
        public ActionResult<Candidate> GetById(int id)
        {
            var Candidate = _service.GetById(id);
            if (Candidate == null)
            {
                return NotFound();
            }
            return Ok(Candidate);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Candidate", Description = "Create a new Candidate.")]
        [SwaggerResponse(201, "Returns the newly created Candidate", typeof(Candidate))]
        public ActionResult<Candidate> Create(Candidate Candidate)
        {
            _service.Add(Candidate);
            return CreatedAtAction(nameof(GetById), new { id = Candidate.Id }, Candidate);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing Candidate", Description = "Update an existing Candidate.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(400, "If the ID in the URL does not match the ID in the request body")]
        public IActionResult Update(int id, Candidate Candidate)
        {
            if (id != Candidate.Id)
            {
                return BadRequest();
            }
            _service.Update(Candidate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Candidate", Description = "Delete a Candidate by its ID.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(404, "If the Candidate with the specified ID does not exist")]
        public IActionResult Delete(int id)
        {
            var Candidate = _service.GetById(id);
            if (Candidate == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
        }
    }

}
