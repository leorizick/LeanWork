using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public interface ICandidateTechnologyRepository
    {
        IEnumerable<CandidateTechnology> GetAll();
        CandidateTechnology GetById(int id);
        void Add(CandidateTechnology entity);
        void Update(CandidateTechnology entity);
        void Delete(int id);
    }
}
