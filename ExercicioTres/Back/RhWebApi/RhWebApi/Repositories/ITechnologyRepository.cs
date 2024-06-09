using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public interface ITechnologyRepository
    {
        IEnumerable<Technology> GetAll();
        Technology GetById(int id);
        void Add(Technology entity);
        void Update(Technology entity);
        void Delete(int id);
    }
}
