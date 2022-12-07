using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService = new EmployeeManager(new EfEmployeeDal());

        [HttpGet]
        public List<Employee> GetAll()
        {
            return employeeService.GetAll();
        }
    }
}
