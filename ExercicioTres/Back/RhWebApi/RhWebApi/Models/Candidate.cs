using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class Candidate
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? VacancyId { get; set; }
        [ForeignKey("VacancyId")]
        public Vacancy? Vacancy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation {  get; set; }
    }
}
