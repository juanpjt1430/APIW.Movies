using APIW.Movies.DAL.Models;
using APIW.Movies.DAL.Models.Dtos;
using APIW.Movies.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIW.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET ALL
        [HttpGet(Name = "GetMoviesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<MovieDto>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(_mapper.Map<ICollection<MovieDto>>(movies));
        }

        // GET BY ID
        [HttpGet("{id:int}", Name = "GetMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
                return NotFound(new { message = "La película no existe" });

            return Ok(_mapper.Map<MovieDto>(movie));
        }

        // CREATE
        [HttpPost(Name = "CreateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync([FromBody] MovieCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _movieService.CreateAsync(dto);

                return CreatedAtRoute(
                    "GetMovieAsync",
                    new { id = created.Id },
                    _mapper.Map<MovieDto>(created)
                );
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno al crear la película" });
            }
        }

        // UPDATE
        [HttpPut("{id:int}", Name = "UpdateMovieAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDto>> UpdateMovieAsync(int id, [FromBody] MovieCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await _movieService.UpdateAsync(id, dto);

                if (updated == null)
                    return NotFound(new { message = "La película no existe" });

                return Ok(_mapper.Map<MovieDto>(updated));
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno al actualizar la película" });
            }
        }

        // DELETE
        [HttpDelete("{id:int}", Name = "DeleteMovieAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                var deleted = await _movieService.DeleteAsync(id);

                if (!deleted)
                    return NotFound(new { message = "La película no existe" });

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno al eliminar la película" });
            }
        }
    }
}