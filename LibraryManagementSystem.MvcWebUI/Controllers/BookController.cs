using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
	public class BookController : Controller
	{
		private IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		public IActionResult Index()
		{
			var books = _bookService.GetAllBooksWithDetails().Data;
			return View(books);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Book book)
		{
			if(!ModelState.IsValid)
				return View(book);
			_bookService.Add(book);
			return RedirectToAction("Index");
		}
	}
}
