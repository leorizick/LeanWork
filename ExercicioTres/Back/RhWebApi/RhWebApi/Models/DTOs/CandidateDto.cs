namespace RhWebApi.Models
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public List<CandidateTechnology> Technologies { get; set; }
        public DateTime Creation { get; set; }
    }
}
