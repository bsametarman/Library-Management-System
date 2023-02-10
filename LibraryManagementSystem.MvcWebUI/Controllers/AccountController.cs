using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Core.Utilities.Roles;
using LibraryManagementSystem.Entities.Concrete;
using LibraryManagementSystem.MvcWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<AppUser> _userManager;
		private SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult SignIn()
		{
			return View();
		}

		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel userCredentials)
		{
			if (!ModelState.IsValid)
				return View(userCredentials);

			var findUser = await _userManager.FindByEmailAsync(userCredentials.Email);

			if (findUser != null)
				return View(userCredentials);

			AppUser user = new AppUser
			{
				Name = userCredentials.Name,
				Surname = userCredentials.Surname,
				IdentityNumber = userCredentials.IdentityNumber,
				Email = userCredentials.Email,
				Password = userCredentials.Password,
				BirthYear = userCredentials.BirthYear,
				PhoneNumber = userCredentials.PhoneNumber,
				Gender = userCredentials.Gender,
				IsActive = true,
				CreatedDate = DateTime.Now,
				ExpirationDate = DateTime.Now.AddYears(1),
				Debt = 0,
				BorrowedBookNumber = 0,
				UserRole = "user"
			};

			var result = await _userManager.CreateAsync(user, userCredentials.Password);

			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, UserRoles.User);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
			return View(userCredentials);
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null)
			{
				if (user.ExpirationDate.Subtract(DateTime.Now).TotalDays > 0 && user.IsActive == true)
				{
					var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
					if (passwordCheck)
					{
						var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
						if (result.Succeeded)
						{
							return RedirectToAction("Index", "Home");
						}
					}
					return View(model);
				}
				else
				{
					return View(model);
				}
			}
			return RedirectToAction("SignIn");
		}
	}
}
