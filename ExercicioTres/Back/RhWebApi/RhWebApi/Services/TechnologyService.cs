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

        public TechnologyDto Add(TechnologyDto dto)
        {
            Technology technology = new Technology()
            {
                Name = dto.Name
            };
            _repository.Add(technology);
            dto.Id = technology.Id;
            return dto;
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
