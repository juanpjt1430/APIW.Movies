using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using APIW.Movies.Repository.IRepository;
using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using APIW.Movies.Repository.IRepository;
using APIW.Movies.Services.IServices;
using AutoMapper;

namespace APIW.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ICollection<MovieDto>> GetAllAsync()
        {
            var movies = await _repo.GetAllAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto?> GetByIdAsync(int id)
        {
            var movie = await _repo.GetByIdAsync(id);
            return movie == null ? null : _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateAsync(MovieCreateDto dto)
        {
            // Validación de duplicado por nombre
            if (await _repo.ExistsByNameAsync(dto.Name))
                throw new InvalidOperationException("Ya existe una película con ese nombre.");

            var movie = _mapper.Map<Movie>(dto);
            var created = await _repo.CreateAsync(movie);
            return _mapper.Map<MovieDto>(created);
        }

        public async Task<MovieDto?> UpdateAsync(int id, MovieCreateDto dto)
        {
            var movie = await _repo.GetByIdAsync(id);
            if (movie == null) return null;

            // Si el nombre cambia, validar duplicado
            if (!string.Equals(movie.Name, dto.Name, StringComparison.OrdinalIgnoreCase)
                && await _repo.ExistsByNameAsync(dto.Name))
            {
                throw new InvalidOperationException("Ya existe otra película con ese nombre.");
            }

            _mapper.Map(dto, movie);
            var updated = await _repo.UpdateAsync(movie);
            return _mapper.Map<MovieDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
