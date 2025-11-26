using APIW.Movies.DAL.Models;
using APIW.Movies.Repository.IRepository;
using APIW.Movies.Services.IServices;

namespace APIW.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            return await _repo.CreateAsync(movie);
        }

        public async Task<Movie?> UpdateAsync(int id, Movie movie)
        {
            if (!await _repo.ExistsAsync(id))
                return null;

            movie.Id = id;

            await _repo.UpdateAsync(movie);
            return movie;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _repo.GetByIdAsync(id);
            if (obj == null) return false;

            await _repo.DeleteAsync(obj);
            return true;
        }
    }
}
