using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        IAuthorService _authorService = new AuthorManager(new EfAuthorDal());

        [HttpGet("getAll")]
        public List<Author> GetAll()
        {
            return _authorService.GetAll();
        }
    }
}
