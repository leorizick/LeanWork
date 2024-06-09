using RhWebApi.Models;

namespace RhWebApi.Services
{
    public interface ICandidateTechnologyService
    {
        IEnumerable<CandidateTechnologyDto> GetAll();
        CandidateTechnologyDto GetById(int id);
        void Add(CandidateTechnology entity);
        void Update(CandidateTechnology entity);
        void Delete(int id);
    }
}
