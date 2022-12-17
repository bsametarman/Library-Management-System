using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.Business.DependencyResolvers.Ninject;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        IGenreService genreService = InstanceFactory.GetInstance<IGenreService>();

        [HttpGet("getAllGenres")]
        public IActionResult GetAll()
        {
            var result = genreService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Genre>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = genreService.GetById(id);
            if (result.Success)
                return Ok(new SuccessDataResult<Genre>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("addGenre")]
        public IActionResult Add(Genre genre)
        {
            var result = genreService.Add(genre);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpDelete("deleteGenre")]
        public IActionResult Delete(Genre genre)
        {
            var result = genreService.Delete(genre);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updateGenre")]
        public IActionResult Update(Genre genre)
        {
            var result = genreService.Update(genre);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
