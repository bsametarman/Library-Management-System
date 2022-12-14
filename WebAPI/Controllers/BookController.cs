using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IBookService bookService = new BookManager(new EfBookDal());

        [HttpGet("getAllBooks")]
        public IActionResult GetAll()
        {
            var result = bookService.GetAll();

            if (result.Success)
                return Ok(new SuccessDataResult<List<Book>>(result.Data, result.Message));

            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = bookService.GetById(id);
            if (result.Success)
                return Ok(new SuccessDataResult<Book>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("addBook")]
        public IActionResult Add(Book book)
        {
            var result = bookService.Add(book);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
