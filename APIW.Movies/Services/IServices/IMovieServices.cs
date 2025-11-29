using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;

namespace APIW.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync(MovieCreateDto dto);
        Task<Movie?> UpdateAsync(int id, MovieCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
