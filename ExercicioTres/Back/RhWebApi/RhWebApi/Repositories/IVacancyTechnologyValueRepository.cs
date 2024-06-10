using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public interface IVacancyTechnologyValueRepository
    {
        IEnumerable<VacancyTechnologyValue> GetAll();
        IEnumerable<VacancyTechnologyValue> GetAllByVacancyId(int Id);
        VacancyTechnologyValue GetById(int id);
        void Add(VacancyTechnologyValue entity);
        void Update(VacancyTechnologyValue entity);
        void Delete(int id);
    }
}
