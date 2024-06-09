using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Repositories;

namespace RhWebApi.Services
{
    public class VacancyTechnologyValueService : IVacancyTechnologyValueService
    {
        private readonly IVacancyTechnologyValueRepository _repository;
        private readonly IMapper _mapper;

        public VacancyTechnologyValueService(IVacancyTechnologyValueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<VacancyTechnologyValueDto> GetAll()
        {
            return _mapper.Map<IEnumerable<VacancyTechnologyValueDto>>(_repository.GetAll());
        }

        public VacancyTechnologyValueDto GetById(int id)
        {
            return _mapper.Map<VacancyTechnologyValueDto>(_repository.GetById(id));
        }

        public void Add(VacancyTechnologyValue entity)
        {
            _repository.Add(entity);
        }

        public void Update(VacancyTechnologyValue entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
