using RhWebApi.Config;
using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly AppDbContext _context;

        public VacancyRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vacancy> GetAll()
        {
            return _context.Vacancies.ToList();
        }

        public Vacancy GetById(int id)
        {
            return _context.Vacancies.Find(id);
        }

        public void Add(Vacancy entity)
        {
            _context.Vacancies.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Vacancy entity)
        {
            _context.Vacancies.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Vacancies.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
