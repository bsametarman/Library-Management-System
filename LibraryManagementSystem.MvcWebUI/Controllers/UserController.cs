using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
	public class UserController : Controller
	{
		private IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SignUp(User user)
		{
			if (!ModelState.IsValid)
				return View(user);
			var result = user;
			result.Debt = 0;
			result.BorrowedBookNumber = 0;
			_userService.Add(result);
			return RedirectToAction("Index");
		}
	}
}
