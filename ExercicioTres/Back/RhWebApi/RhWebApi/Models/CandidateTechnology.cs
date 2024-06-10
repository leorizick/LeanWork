using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class CandidateTechnology
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public Technology Technology { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation { get; set; }
    }
}
