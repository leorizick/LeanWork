using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class VacancyDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Creation { get; set; }
    }
}
