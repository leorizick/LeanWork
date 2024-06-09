using RhWebApi.Config;
using RhWebApi.Models;

namespace RhWebApi.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Candidate> GetAll()
        {
            return _context.Candidates.ToList();
        }

        public Candidate GetById(int id)
        {
            return _context.Candidates.Find(id);
        }

        public void Add(Candidate entity)
        {
            _context.Candidates.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Candidate entity)
        {
            _context.Candidates.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _context.Candidates.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
