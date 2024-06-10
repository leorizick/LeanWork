using Microsoft.AspNetCore.Mvc;
using RhWebApi.Models;
using RhWebApi.Models.DTOs;
using RhWebApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RhWebApi.Controllers
{
    [ApiController]
    //tag [controller] pega dinamicamente o nome da classe sem o sufixo controller, deixando facilitado a manutenção do codigo
    [Route("api/[controller]")]
    public class FinalReportController : ControllerBase
    {
        private readonly IFinalReport _finalReport;

        public FinalReportController(IFinalReport finalReport)
        {
            _finalReport = finalReport;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get the report of candidates in vacancy", Description = "Get all Candidates.")]
        [SwaggerResponse(200, "Returns the list of Candidates in the report", typeof(IEnumerable<ReportDto>))]
        public ActionResult<IEnumerable<List<ReportDto>>> GenerateReport(List<VacancyTechnologyValueDto> vacancyTechnologyValueDto)
        {
            var report = _finalReport.GenerateReport(vacancyTechnologyValueDto);
            return Ok(report);
        }
    }

}
