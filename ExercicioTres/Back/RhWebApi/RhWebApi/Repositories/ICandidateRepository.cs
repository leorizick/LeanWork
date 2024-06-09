using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetAll();
        Candidate GetById(int id);
        void Add(Candidate entity);
        void Update(Candidate entity);
        void Delete(int id);
    }
}
