using RhWebApi.Config;
using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly AppDbContext _context;

        public TechnologyRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Technology> GetAll()
        {
            return _context.Technologies.ToList();
        }

        public Technology GetById(int id)
        {
            return _context.Technologies.Find(id);
        }

        public void Add(Technology entity)
        {
            _context.Technologies.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Technology entity)
        {
            _context.Technologies.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Technologies.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
