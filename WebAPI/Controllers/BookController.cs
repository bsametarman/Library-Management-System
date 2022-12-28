using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.Business.DependencyResolvers.Ninject;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.ComplexTypes;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        IBookService bookService = InstanceFactory.GetInstance<IBookService>();

        [HttpGet("getAllBooks")]
        public IActionResult GetAll()
        {
            var result = bookService.GetAll();

            if (result.Success)
                return Ok(new SuccessDataResult<List<Book>>(result.Data, result.Message));

            return BadRequest(result.Message);
        }

        [HttpGet("getAllBooksWithDetails")]
        public IActionResult GetAllBooksWithDetails()
        {
	        var result = bookService.GetAllBooksWithDetails();

	        if (result.Success)
		        return Ok(new SuccessDataResult<List<BookDetail>>(result.Data, result.Message));

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

        [HttpDelete("deleteBook")]
        public IActionResult Delete(Book book)
        {
            var result = bookService.Delete(book);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updateBook")]
        public IActionResult Update(Book book)
        {
            var result = bookService.Update(book);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
