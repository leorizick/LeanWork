using Microsoft.AspNetCore.Mvc;
using RhWebApi.Models;
using RhWebApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RhWebApi.Controllers
{
    [ApiController]
    //tag [controller] pega dinamicamente o nome da classe sem o sufixo controller, deixando facilitado a manutenção do codigo
    [Route("api/[controller]")]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _service;

        public TechnologyController(ITechnologyService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all Technologies", Description = "Get all Technologies.")]
        [SwaggerResponse(200, "Returns the list of Technologies", typeof(IEnumerable<Technology>))]
        public ActionResult<IEnumerable<Technology>> GetAll()
        {
            var Technologies = _service.GetAll();
            return Ok(Technologies);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Technology by ID", Description = "Get a specific Technology by its ID.")]
        [SwaggerResponse(200, "Returns the Technology", typeof(Technology))]
        [SwaggerResponse(404, "If the Technology with the specified ID does not exist")]
        public ActionResult<Technology> GetById(int id)
        {
            var Technology = _service.GetById(id);
            if (Technology == null)
            {
                return NotFound();
            }
            return Ok(Technology);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Technology", Description = "Create a new Technology.")]
        [SwaggerResponse(201, "Returns the newly created Technology", typeof(TechnologyDto))]
        public ActionResult<TechnologyDto> Create(TechnologyDto Technology)
        {
            _service.Add(Technology);
            return CreatedAtAction(nameof(GetById), new { id = Technology.Id }, Technology);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing Technology", Description = "Update an existing Technology.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(400, "If the ID in the URL does not match the ID in the request body")]
        public IActionResult Update(int id, Technology Technology)
        {
            if (id != Technology.Id)
            {
                return BadRequest();
            }
            _service.Update(Technology);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Technology", Description = "Delete a Technology by its ID.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(404, "If the Technology with the specified ID does not exist")]
        public IActionResult Delete(int id)
        {
            var Technology = _service.GetById(id);
            if (Technology == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
        }
    }

}
