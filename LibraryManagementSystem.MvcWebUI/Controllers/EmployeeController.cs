using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
	public class EmployeeController : Controller
	{
		private IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		public IActionResult Index()
		{
			var results = _employeeService.GetAll().Data;
			return View(results);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Employee employee)
		{
			if(!ModelState.IsValid)
				return View(employee);
			var result = employee;
			result.BorrowedBookNumber = 0;
			_employeeService.Add(result);
			return RedirectToAction("Index");
		}

	}
}
