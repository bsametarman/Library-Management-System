using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController
    {
        IGenreService genreService = new GenreManager(new EfGenreDal());

        [HttpGet]
        public List<Genre> GetAll()
        {
            return genreService.GetAll();
        }
    }
}
