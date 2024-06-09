using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public interface IVacancyRepository
    {
        IEnumerable<Vacancy> GetAll();
        Vacancy GetById(int id);
        void Add(Vacancy entity);
        void Update(Vacancy entity);
        void Delete(int id);
    }
}
