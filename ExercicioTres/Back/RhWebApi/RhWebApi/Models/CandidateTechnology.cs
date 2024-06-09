using System.ComponentModel.DataAnnotations.Schema;

namespace RhWebApi.Models
{
    public class CandidateTechnology
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
        public int Knowledge {  get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creation { get; set; }
    }
}
