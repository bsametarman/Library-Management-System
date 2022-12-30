using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
	public class GenreController : Controller
	{
		private IGenreService _genreService;

		public GenreController(IGenreService genreService)
		{
			_genreService = genreService;
		}

		public IActionResult Index()
		{
			var results = _genreService.GetAll().Data;
			return View(results);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Genre genre)
		{
			if(!ModelState.IsValid)
				return View(genre);
			_genreService.Add(genre);
			return RedirectToAction("Index");
		}

	}
}
