using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using LibraryManagementSystem.MvcWebUI.Models;
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

		//public IActionResult Index()
		//{
		//	return View();
		//}

		public IActionResult SignIn()
		{
			return View();
		}

		public IActionResult SignUp()
		{
			return View();
		}

		public IActionResult SignUpSuccess()
		{
			return View();
		}

		public IActionResult SignInSuccess()
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
			return RedirectToAction("SignUpSuccess");
		}

		[HttpPost]
		public IActionResult SignIn(UserSignInViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			var result = _userService.GetByEmailAndPassword(model.Email, model.Password);
			if (result.Success)
				return RedirectToAction("SignInSuccess");
			return RedirectToAction("SignIn");
		}

		public IActionResult Users()
		{
			var results = _userService.GetAll().Data;
			return View(results);
		}
	}
}
