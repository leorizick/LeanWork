using Microsoft.AspNetCore.Mvc;
using RhWebApi.Models;
using RhWebApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RhWebApi.Controllers
{
    [ApiController]
    //tag [controller] pega dinamicamente o nome da classe sem o sufixo controller, deixando facilitado a manutenção do codigo
    [Route("api/[controller]")]
    public class VacancyTechnologyValueController : ControllerBase
    {
        private readonly IVacancyTechnologyValueService _service;

        public VacancyTechnologyValueController(IVacancyTechnologyValueService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all VacancyTechnologyValues", Description = "Get all VacancyTechnologyValues.")]
        [SwaggerResponse(200, "Returns the list of VacancyTechnologyValues", typeof(IEnumerable<VacancyTechnologyValue>))]
        public ActionResult<IEnumerable<VacancyTechnologyValue>> GetAll()
        {
            var VacancyTechnologyValues = _service.GetAll();
            return Ok(VacancyTechnologyValues);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get VacancyTechnologyValue by ID", Description = "Get a specific VacancyTechnologyValue by its ID.")]
        [SwaggerResponse(200, "Returns the VacancyTechnologyValue", typeof(VacancyTechnologyValue))]
        [SwaggerResponse(404, "If the VacancyTechnologyValue with the specified ID does not exist")]
        public ActionResult<VacancyTechnologyValue> GetById(int id)
        {
            var VacancyTechnologyValue = _service.GetById(id);
            if (VacancyTechnologyValue == null)
            {
                return NotFound();
            }
            return Ok(VacancyTechnologyValue);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new VacancyTechnologyValue", Description = "Create a new VacancyTechnologyValue.")]
        [SwaggerResponse(201, "Returns the newly created VacancyTechnologyValue", typeof(VacancyTechnologyValue))]
        public ActionResult<VacancyTechnologyValue> Create(VacancyTechnologyValue VacancyTechnologyValue)
        {
            _service.Add(VacancyTechnologyValue);
            return CreatedAtAction(nameof(GetById), new { id = VacancyTechnologyValue.Id }, VacancyTechnologyValue);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing VacancyTechnologyValue", Description = "Update an existing VacancyTechnologyValue.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(400, "If the ID in the URL does not match the ID in the request body")]
        public IActionResult Update(int id, VacancyTechnologyValue VacancyTechnologyValue)
        {
            if (id != VacancyTechnologyValue.Id)
            {
                return BadRequest();
            }
            _service.Update(VacancyTechnologyValue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a VacancyTechnologyValue", Description = "Delete a VacancyTechnologyValue by its ID.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(404, "If the VacancyTechnologyValue with the specified ID does not exist")]
        public IActionResult Delete(int id)
        {
            var VacancyTechnologyValue = _service.GetById(id);
            if (VacancyTechnologyValue == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
        }
    }

}
