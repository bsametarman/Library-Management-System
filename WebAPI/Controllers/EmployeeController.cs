using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.Business.DependencyResolvers.Ninject;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService = InstanceFactory.GetInstance<IEmployeeService>();

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = employeeService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Employee>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }
    }
}
