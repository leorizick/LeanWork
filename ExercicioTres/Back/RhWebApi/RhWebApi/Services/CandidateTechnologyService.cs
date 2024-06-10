using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Repositories;

namespace RhWebApi.Services
{
    public class CandidateTechnologyService : ICandidateTechnologyService
    {
        private readonly ICandidateTechnologyRepository _repository;
        private readonly IMapper _mapper;

        public CandidateTechnologyService(ICandidateTechnologyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CandidateTechnologyDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CandidateTechnologyDto>>(_repository.GetAll());
        }

        public IEnumerable<CandidateTechnology> GetAllByCandidateId(int id)
        {
            return _repository.GetAllByCandidateId(id);
        }

        public CandidateTechnologyDto GetById(int id)
        {
            return _mapper.Map<CandidateTechnologyDto>(_repository.GetById(id));
        }

        public void Add(CandidateTechnology entity)
        {
            _repository.Add(entity);
        }

        public void Update(CandidateTechnology entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
