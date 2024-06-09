using RhWebApi.Models;

namespace RhWebApi.Services
{
    public interface IVacancyTechnologyValueService
    {
        IEnumerable<VacancyTechnologyValueDto> GetAll();
        VacancyTechnologyValueDto GetById(int id);
        void Add(VacancyTechnologyValue entity);
        void Update(VacancyTechnologyValue entity);
        void Delete(int id);
    }
}
