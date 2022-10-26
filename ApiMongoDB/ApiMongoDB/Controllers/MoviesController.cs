using Microsoft.AspNetCore.Mvc;
using ApiMongoDB.Collection;
using ApiMongoDB.Repository;

namespace ApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _moviesRepository.GetAllAsync();
            return Ok(people);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var people = await _moviesRepository.GetByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Movie newMovie)
        {
            await _moviesRepository.CreateNewMovieAsync(newMovie);
            return CreatedAtAction(nameof(Get), new { id = newMovie.Id }, newMovie);
        }


        [HttpPut]
        public async Task<IActionResult> Put(Movie updateMovie)
        {
            var people = await _moviesRepository.GetByIdAsync(updateMovie.Id);
            if (people == null)
            {
                return NotFound();
            }

            await _moviesRepository.UpdateMovieAsync(updateMovie);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var people = await _moviesRepository.GetByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            await _moviesRepository.DeleteMovieAsync(id);
            return NoContent();
        }
    }
}
