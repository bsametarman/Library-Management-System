using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
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

        [HttpGet("getallbooks")]
        public List<Book> GetAll()
        {
            return bookService.GetAll();
        }

        [HttpGet("getbyid")]
        public Book GetById(int id)
        {
            return bookService.GetById(id);
        }

        [HttpPost("addbook")]
        public void Add(Book book)
        {
            bookService.Add(book);
        }
    }
}
