using APIW.Movies.DAL.Models.Dtos;

namespace APIW.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetAllAsync();
        Task<MovieDto?> GetByIdAsync(int id);
        Task<MovieDto> CreateAsync(MovieCreateDto dto);
        Task<MovieDto?> UpdateAsync(int id, MovieCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
