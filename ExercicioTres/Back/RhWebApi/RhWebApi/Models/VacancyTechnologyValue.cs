using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class VacancyTechnologyValue
    {
        public int Id { get; set; }
        public Vacancy Vacancy { get; set; }
        public Technology Technology { get; set; }
        public int? Value { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation { get; set; }
    }
}
