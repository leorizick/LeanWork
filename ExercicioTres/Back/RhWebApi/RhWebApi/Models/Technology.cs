using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation { get; set; }
    }
}
