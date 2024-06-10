using RhWebApi.Models;

namespace RhWebApi.Services
{
    public interface IVacancyService
    {
        IEnumerable<VacancyDto> GetAll();
        VacancyDto GetById(int id);
        VacancyDto Add(VacancyDto entity);
        void Update(Vacancy entity);
        void Delete(int id);
    }
}
