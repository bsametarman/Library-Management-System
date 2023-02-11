using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private IUserService _userService;
        private UserManager<AppUser> _userManager;

        public DashboardController(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var userId = _userManager.GetUserId(HttpContext.User);
            var viewBagUser = _userManager.FindByIdAsync(userId);
            ViewBag.UserDebt = viewBagUser.Result.Debt;
            ViewBag.UserBookCount = viewBagUser.Result.BorrowedBookNumber;
            
            if (User.IsInRole("admin") || User.IsInRole("moderator"))
            {
                List<AppUser> usersWithUserRole = new List<AppUser>();
                var users = _userService.GetAll();
                foreach (var user in users.Data)
                {
                    bool isNormalUser = true;
                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        if (role == "admin" || role == "moderator")
                            isNormalUser = false;
                    }
                    if (isNormalUser)
                        usersWithUserRole.Add(user);
                }
                return View(usersWithUserRole);
            }
            return View();
        }

        public async Task<IActionResult> AdminList()
        {
            List<AppUser> usersWithUserRole = new List<AppUser>();
            var users = _userService.GetAll();
            foreach (var user in users.Data)
            {
                bool isAdmin = false;
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    if (role == "admin" || role == "moderator")
                        isAdmin = true;
                }
                if (isAdmin)
                    usersWithUserRole.Add(user);
            }
            return View(usersWithUserRole);
        }
    }
}
