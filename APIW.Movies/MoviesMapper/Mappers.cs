using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using AutoMapper;

namespace APIW.Movies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            // Category mappings
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();

            // Movie mappings
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateDto>().ReverseMap();
        }
    }
}
