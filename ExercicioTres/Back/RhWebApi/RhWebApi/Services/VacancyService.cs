using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Repositories;

namespace RhWebApi.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository _repository;
        private readonly IMapper _mapper;

        public VacancyService(IVacancyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<VacancyDto> GetAll()
        {
            return _mapper.Map<IEnumerable<VacancyDto>>(_repository.GetAll());
        }

        public VacancyDto GetById(int id)
        {
            return _mapper.Map<VacancyDto>(_repository.GetById(id));
        }
        public void Add(Vacancy entity)
        {
            _repository.Add(entity);
        }

        public void Update(Vacancy entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
