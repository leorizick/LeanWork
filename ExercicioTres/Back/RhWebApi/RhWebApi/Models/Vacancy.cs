using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<VacancyTechnologyValue>? VacancyTechnologyValues { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation { get; set; }
    }
}
