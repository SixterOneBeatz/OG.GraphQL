using AutoMapper;
using OG.GraphQL.Application.Common.DTOs;
using OG.GraphQL.Domain.Entities;

namespace OG.GraphQL.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
