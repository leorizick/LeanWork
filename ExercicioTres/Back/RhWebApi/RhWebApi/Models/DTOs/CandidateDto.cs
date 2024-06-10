namespace RhWebApi.Models
{
    public class CandidateDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public VacancyDto Vacancy { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
        public DateTime Creation { get; set; }
    }
}
