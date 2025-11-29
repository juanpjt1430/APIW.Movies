using APIW.Movies.DAL.Models;

namespace APIW.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie movie);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByIdAsync(int id);
    }
}
