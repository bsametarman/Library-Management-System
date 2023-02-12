using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Core.Utilities.Roles;
using LibraryManagementSystem.Entities.Concrete;
using LibraryManagementSystem.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private UserManager<AppUser> _userManager;
		private SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[AllowAnonymous]
		public IActionResult SignIn()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult SignUp()
		{
			return View();
		}

        public IActionResult ModeratorRegister()
        {
            return View();
        }

        public IActionResult RoleChange(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult ExtendTime(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult PasswordChange(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult UsernameChange(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
		[AllowAnonymous]
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
				UserName = userCredentials.Name,
				IsActive = true,
				CreatedDate = DateTime.Now,
				ExpirationDate = DateTime.Now.AddYears(1),
				Debt = 0,
				BorrowedBookNumber = 0,
				EmailConfirmed = true,
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
		[AllowAnonymous]
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

        [HttpPost]
        public async Task<IActionResult> ModeratorRegister(UserRegisterViewModel userCredentials)
        {
            if (ModelState.IsValid)
            {
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
                    UserName = userCredentials.Name,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddYears(1),
                    Debt = 0,
                    BorrowedBookNumber = 0,
                    EmailConfirmed = true,
                    UserRole = "moderator"
                };

                var result = await _userManager.CreateAsync(user, userCredentials.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Moderator);
                    return RedirectToAction("AdminList", "Dashboard");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(userCredentials);
        }

        public async Task<IActionResult> EditActiveState(string id)
        {
            if (User.IsInRole("admin"))
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return View("Not Found");
                }
                if (user.IsActive == true)
                {
                    user.IsActive = false;
                }
                else
                {
                    user.IsActive = true;
                }

                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            if (User.IsInRole("admin"))
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return View("Not Found");
                }

                await _userManager.DeleteAsync(user);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> UserExtendTime(string id, int dayToExtend)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return View(id);

            user.ExpirationDate = user.ExpirationDate.AddDays(dayToExtend);
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> UserPasswordChange(string id, string password)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return View(id);

            user.Password = password;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> UserUsernameChange(string id, string username)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return View(id);

            user.UserName = username;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> UserRoleChange(string id, string role)
        {
            List<string> roles = new List<string>() { "user", "moderator", "admin"};
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return View(id);

            foreach (var roleitem in roles)
            {
                await _userManager.RemoveFromRoleAsync(user, roleitem);
            }

            user.UserRole = role;
            await _userManager.AddToRoleAsync(user, role);
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
