namespace RhWebApi.Models
{
    public class CandidateTechnologyDto
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public Technology Technology { get; set; }
    }
}
