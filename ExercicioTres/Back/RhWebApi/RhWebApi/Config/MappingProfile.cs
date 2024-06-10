using AutoMapper;
using RhWebApi.Models;
using RhWebApi.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidateDto>();
        CreateMap<Vacancy, VacancyDto>();
        CreateMap<CandidateTechnology, CandidateTechnologyDto>();
        CreateMap<Technology, TechnologyDto>();
        CreateMap<VacancyTechnologyValue, VacancyTechnologyValueDto>();
        CreateMap<Candidate, CandidateDto>();
    }
}