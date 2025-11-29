using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using APIW.Movies.Repository.IRepository;
using APIW.Movies.Services.IServices;

namespace APIW.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ICollection<Movie>> GetAllAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> CreateAsync(MovieCreateDto dto)
        {
            // Validar duplicado
            if (await _movieRepository.ExistsByTitleAsync(dto.Title))
                throw new InvalidOperationException("Ya existe una película con este título.");

            var movie = new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Year = dto.Year,
                Director = dto.Director
            };

            return await _movieRepository.CreateAsync(movie);
        }

        public async Task<Movie?> UpdateAsync(int id, MovieCreateDto dto)
        {
            var existing = await _movieRepository.GetByIdAsync(id);

            if (existing == null)
                return null;

            // Validación por título repetido
            if (existing.Title != dto.Title &&
                await _movieRepository.ExistsByTitleAsync(dto.Title))
                throw new InvalidOperationException("Ya existe otra película con ese título.");

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.Year = dto.Year;
            existing.Director = dto.Director;

            return await _movieRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _movieRepository.DeleteAsync(id);
        }
    }
}
