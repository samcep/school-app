using AutoMapper;
using school_app.Dtos;
using school_app.Entities;

namespace school_app.Mappers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CourseCreateDto, Course>();
        }
    }
}
