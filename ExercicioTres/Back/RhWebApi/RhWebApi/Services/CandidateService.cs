using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Repositories;

namespace RhWebApi.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;
        private readonly ICandidateTechnologyService _candidateTechnologyService;
        private readonly ITechnologyService _technologyService;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IVacancyService _vacancyService;
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository repository, IMapper mapper, ICandidateTechnologyRepository candidateTechnologyRepository, ICandidateTechnologyService candidateTechnologyService, ITechnologyService technologyService, IVacancyService vacancyService, IVacancyRepository vacancyRepository, ITechnologyRepository technologyRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _candidateTechnologyService = candidateTechnologyService;
            _technologyService = technologyService;
            _vacancyService = vacancyService;
            _vacancyRepository = vacancyRepository;
            _technologyRepository = technologyRepository;
        }

        public IEnumerable<CandidateDto> GetAll()
        {
            var candidatesDtolist = new List<CandidateDto>();
            var candidates = _repository.GetAll();

            foreach (var candidate in candidates)
            {
                var candidateDto = CandidateDtoMapper(candidate);
                candidatesDtolist.Add(candidateDto);
            }
            return candidatesDtolist;
        }

        public CandidateDto GetById(int id)
        {
            var candidate = _repository.GetById(id);
            return CandidateDtoMapper(candidate);
        }

        public void Add(CandidateDto dto)
        {
            var vacancy = _vacancyRepository.GetById(dto.Vacancy.Id.Value);
            Candidate candidate = new Candidate()
            {
                Creation = dto.Creation,
                Name = dto.Name,
                Vacancy = vacancy,
                VacancyId = vacancy.Id,
            };
            _repository.Add(candidate);

            foreach (var technology in dto.Technologies)
            {
                var tech = _technologyRepository.GetById(technology.Id.Value);
                _candidateTechnologyService.Add(new CandidateTechnology() { Candidate = candidate, Technology = tech });
            }
        }

        public void Update(Candidate entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        private CandidateDto CandidateDtoMapper(Candidate candidate)
        {
            if (candidate == null)
            {
                return null;
            }
            List<TechnologyDto> technologies = new List<TechnologyDto>();
            VacancyDto vacancyDto;

            var technologiesList = _candidateTechnologyService.GetAllByCandidateId(candidate.Id.Value);
            foreach(var tech in technologiesList)
            {
                var entity = _technologyService.GetById(tech.Id);
                if(entity != null)
                technologies.Add(new TechnologyDto() { Creation = entity.Creation, Id = entity.Id, Name = entity.Name });
            }

            vacancyDto = new VacancyDto();
            if (candidate.VacancyId != null)
            {
                var vacancy = _vacancyService.GetById(candidate.VacancyId.Value);
                vacancyDto.Creation = vacancy.Creation;
                vacancyDto.Description = vacancy.Description;
                vacancyDto.Name = vacancy.Name;
            }
            return new CandidateDto { Creation = candidate.Creation, Id = candidate.Id, Name = candidate.Name, Technologies = technologies, Vacancy = vacancyDto };
        }
    }
}
