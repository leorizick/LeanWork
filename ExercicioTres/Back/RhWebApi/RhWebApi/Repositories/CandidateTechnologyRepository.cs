using RhWebApi.Config;
using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public class CandidateTechnologyRepository : ICandidateTechnologyRepository
    {
        private readonly AppDbContext _context;

        public CandidateTechnologyRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CandidateTechnology> GetAll()
        {
            return _context.CandidateTechnologies.ToList();
        }

        public IEnumerable<CandidateTechnology> GetAllByCandidateId(int id)
        {
            return _context.CandidateTechnologies.Where(c => c.Candidate.Id == id);
        }

        public CandidateTechnology GetById(int id)
        {
            return _context.CandidateTechnologies.Find(id);
        }

        public void Add(CandidateTechnology entity)
        {
            _context.CandidateTechnologies.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CandidateTechnology entity)
        {
            _context.CandidateTechnologies.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.CandidateTechnologies.Remove(entity);
                _context.SaveChanges();
            }
        }


    }
}
