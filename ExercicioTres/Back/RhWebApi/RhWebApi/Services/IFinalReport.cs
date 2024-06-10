using RhWebApi.Models.DTOs;
using RhWebApi.Models;

namespace RhWebApi.Services
{
    public interface IFinalReport
    {
        public List<ReportDto> GenerateReport(List<VacancyTechnologyValueDto> vacancyTechnologyValueDto);
    }
}
