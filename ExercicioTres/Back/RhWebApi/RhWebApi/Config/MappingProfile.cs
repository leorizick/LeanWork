using AutoMapper;
using RhWebApi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidateDto>();
        CreateMap<Vacancy, VacancyDto>(); 
        CreateMap<CandidateTechnology, CandidateTechnologyDto>(); 
        CreateMap<Technology, TechnologyDto>(); 
        CreateMap<VacancyTechnologyValue, VacancyTechnologyValueDto>(); 
    }
}