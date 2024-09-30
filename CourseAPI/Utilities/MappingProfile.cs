using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebAPI.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDtoForUpdate, Course>();
            CreateMap<CourseDtoForInsertion, Course>();
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any()
                ? Math.Round(src.Ratings.Average(r => r.Star), 1)
                : 0))
                .ForMember(dest => dest.RatingCount, opt => opt.MapFrom(src => src.Ratings.Count))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryDto>();

            CreateMap<Rating, RatingDto>().ReverseMap();
        }
    }
}
