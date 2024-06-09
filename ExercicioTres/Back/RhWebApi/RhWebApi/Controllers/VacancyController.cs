using Microsoft.AspNetCore.Mvc;
using RhWebApi.Models;
using RhWebApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RhWebApi.Controllers
{
    [ApiController]
    //tag [controller] pega dinamicamente o nome da classe sem o sufixo controller, deixando facilitado a manutenção do codigo
    [Route("api/[controller]")]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _service;

        public VacancyController(IVacancyService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all vacancies", Description = "Get all vacancies.")]
        [SwaggerResponse(200, "Returns the list of vacancies", typeof(IEnumerable<Vacancy>))]
        public ActionResult<IEnumerable<Vacancy>> GetAll()
        {
            var vacancies = _service.GetAll();
            return Ok(vacancies);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get vacancy by ID", Description = "Get a specific vacancy by its ID.")]
        [SwaggerResponse(200, "Returns the vacancy", typeof(Vacancy))]
        [SwaggerResponse(404, "If the vacancy with the specified ID does not exist")]
        public ActionResult<Vacancy> GetById(int id)
        {
            var vacancy = _service.GetById(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            return Ok(vacancy);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new vacancy", Description = "Create a new vacancy.")]
        [SwaggerResponse(201, "Returns the newly created vacancy", typeof(Vacancy))]
        public ActionResult<Vacancy> Create(Vacancy vacancy)
        {
            _service.Add(vacancy);
            return CreatedAtAction(nameof(GetById), new { id = vacancy.Id }, vacancy);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing vacancy", Description = "Update an existing vacancy.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(400, "If the ID in the URL does not match the ID in the request body")]
        public IActionResult Update(int id, Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return BadRequest();
            }
            _service.Update(vacancy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a vacancy", Description = "Delete a vacancy by its ID.")]
        [SwaggerResponse(204, "Indicates success, but does not return any content")]
        [SwaggerResponse(404, "If the vacancy with the specified ID does not exist")]
        public IActionResult Delete(int id)
        {
            var vacancy = _service.GetById(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
        }
    }

}
