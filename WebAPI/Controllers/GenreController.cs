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

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = genreService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Genre>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            var result = genreService.Add(genre);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
