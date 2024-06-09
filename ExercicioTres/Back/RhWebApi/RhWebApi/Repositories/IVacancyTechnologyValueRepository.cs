using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public interface IVacancyTechnologyValueRepository
    {
        IEnumerable<VacancyTechnologyValue> GetAll();
        VacancyTechnologyValue GetById(int id);
        void Add(VacancyTechnologyValue entity);
        void Update(VacancyTechnologyValue entity);
        void Delete(int id);
    }
}
