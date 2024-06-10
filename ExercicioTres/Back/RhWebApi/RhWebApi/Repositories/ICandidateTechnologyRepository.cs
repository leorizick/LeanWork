using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public interface ICandidateTechnologyRepository
    {
        IEnumerable<CandidateTechnology> GetAll();
        IEnumerable<CandidateTechnology> GetAllByCandidateId(int id);
        CandidateTechnology GetById(int id);
        void Add(CandidateTechnology entity);
        void Update(CandidateTechnology entity);
        void Delete(int id);
    }
}
