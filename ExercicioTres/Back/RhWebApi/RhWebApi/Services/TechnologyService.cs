using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Repositories;

namespace RhWebApi.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _repository;
        private readonly IMapper _mapper;

        public TechnologyService(ITechnologyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TechnologyDto> GetAll()
        {
            return _mapper.Map<IEnumerable<TechnologyDto>>(_repository.GetAll());
        }

        public TechnologyDto GetById(int id)
        {
            return _mapper.Map<TechnologyDto>(_repository.GetById(id));
        }

        public void Add(Technology entity)
        {
            _repository.Add(entity);
        }

        public void Update(Technology entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
