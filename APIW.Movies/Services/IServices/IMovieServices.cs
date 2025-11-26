using APIW.Movies.DAL.Models;

namespace APIW.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Task<Movie?> UpdateAsync(int id, Movie movie);
        Task<bool> DeleteAsync(int id);
    }
}