using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using APIW.Movies.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIW.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(result));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            if (movie == null) return NotFound();

            return Ok(_mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> Create(MovieCreateDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            var created = await _service.CreateAsync(movie);

            return CreatedAtAction(nameof(GetById), new { id = created.Id },
                _mapper.Map<MovieDto>(created));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, MovieCreateDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            var updated = await _service.UpdateAsync(id, movie);

            if (updated == null) return NotFound();

            return Ok(_mapper.Map<MovieDto>(updated));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();

            return NoContent();
        }
    }
}

