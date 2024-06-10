using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Repositories;

namespace RhWebApi.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository _repository;
        private readonly IVacancyTechnologyValueService _vacancyTechnologyValueService;
        private readonly IMapper _mapper;
        public VacancyService(IVacancyRepository repository, IMapper mapper, IVacancyTechnologyValueService vacancyTechnologyValueService)
        {
            _repository = repository;
            _mapper = mapper;
            _vacancyTechnologyValueService = vacancyTechnologyValueService;
        }

        public IEnumerable<VacancyDto> GetAll()
        {
            return _mapper.Map<IEnumerable<VacancyDto>>(_repository.GetAll());
        }

        public VacancyDto GetById(int id)
        {
            return _mapper.Map<VacancyDto>(_repository.GetById(id));
        }
        public VacancyDto Add(VacancyDto dto)
        {
            Vacancy vacancy = new Vacancy() { Description = dto.Description, Name = dto.Name };

            if (dto.Id != null)
            {
                vacancy = _repository.GetById(dto.Id.Value);
            }

            _repository.Add(vacancy);
            dto.Id = vacancy.Id;
            dto.Creation = vacancy.Creation;
            return dto;
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
