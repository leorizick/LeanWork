namespace RhWebApi.Models
{
    public class VacancyTechnologyValueDto
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public int Value { get; set; }
        public DateTime Creation { get; set; }

    }
}
