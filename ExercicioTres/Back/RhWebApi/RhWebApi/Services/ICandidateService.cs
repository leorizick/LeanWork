using RhWebApi.Models;

namespace RhWebApi.Services
{
    public interface ICandidateService
    {
        IEnumerable<CandidateDto> GetAll();
        CandidateDto GetById(int id);
        void Add(Candidate entity);
        void Update(Candidate entity);
        void Delete(int id);
    }
}
