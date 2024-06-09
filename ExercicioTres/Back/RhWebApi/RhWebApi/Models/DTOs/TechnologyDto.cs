using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class TechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Creation { get; set; }
    }
}
