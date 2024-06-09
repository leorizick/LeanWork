using RhWebApi.Models;

namespace RhWebApi.Services
{
    public interface ITechnologyService
    {
        IEnumerable<TechnologyDto> GetAll();
        TechnologyDto GetById(int id);
        void Add(Technology entity);
        void Update(Technology entity);
        void Delete(int id);
    }
}
