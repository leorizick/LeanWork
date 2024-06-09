using RhWebApi.Config;
using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public class VacancyTechnologyValueRepository : IVacancyTechnologyValueRepository
    {
        private readonly AppDbContext _context;

        public VacancyTechnologyValueRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VacancyTechnologyValue> GetAll()
        {
            return _context.vacancyTechnologyValues.ToList();
        }

        public VacancyTechnologyValue GetById(int id)
        {
            return _context.vacancyTechnologyValues.Find(id);
        }

        public void Add(VacancyTechnologyValue entity)
        {
            _context.vacancyTechnologyValues.Add(entity);
            _context.SaveChanges();
        }

        public void Update(VacancyTechnologyValue entity)
        {
            _context.vacancyTechnologyValues.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.vacancyTechnologyValues.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
