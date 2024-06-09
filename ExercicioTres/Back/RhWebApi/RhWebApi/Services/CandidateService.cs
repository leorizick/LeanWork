using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Repositories;

namespace RhWebApi.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CandidateDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CandidateDto>>(_repository.GetAll());
        }

        public CandidateDto GetById(int id)
        {
            return _mapper.Map<CandidateDto>(_repository.GetById(id));
        }

        public void Add(Candidate entity)
        {
            _repository.Add(entity);
        }

        public void Update(Candidate entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
