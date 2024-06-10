using RhWebApi.Models;
using RhWebApi.Models.DTOs;

namespace RhWebApi.Services
{
    public class FinalReport : IFinalReport
    {
        private readonly IVacancyTechnologyValueService _vacancyTechnologyValueService;
        private readonly ICandidateService _candidateService;

        public FinalReport(IVacancyTechnologyValueService vacancyTechnologyValueService, ICandidateService candidateService)
        {
            _vacancyTechnologyValueService = vacancyTechnologyValueService;
            _candidateService = candidateService;
        }

        public List<ReportDto> GenerateReport(List<VacancyTechnologyValueDto> vacancyTechnologyValueDto)
        {
            List<ReportDto> reportList = new List<ReportDto>();
            var candidatesInVacancy = _candidateService.GetAll().Where(c => vacancyTechnologyValueDto.Any(v => v.Vacancy.Id == c.Id));

            foreach (var candidate in candidatesInVacancy)
            {
                int score = 0;
                foreach (var technology in candidate.Technologies)
                {
                    var reg = vacancyTechnologyValueDto.FirstOrDefault(x => x.Technology.Id == technology.Id && x.Vacancy?.Id == technology.Id);
                    if (reg != null)
                    {
                        score += reg.Value;
                    }
                    reportList.Add(new ReportDto() { CandidateName = candidate.Name, VacancyName = reg.Vacancy?.Name, Result = score });
                }
            }

            return reportList.OrderByDescending(x => x.Result).ToList();
        }

    }
}
