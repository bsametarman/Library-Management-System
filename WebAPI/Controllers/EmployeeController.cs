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
        IUserService userService = InstanceFactory.GetInstance<IUserService>();

        [HttpGet("getAllEmployees")]
        public IActionResult GetAll()
        {
            var result = employeeService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Employee>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = employeeService.GetById(id);
            if (result.Success)
                return Ok(new SuccessDataResult<Employee>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("addEmployee")]
        public IActionResult Add(Employee employee)
        {
            var result = employeeService.Add(employee);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpDelete("deleteEmployee")]
        public IActionResult Delete(Employee employee)
        {
            var result = employeeService.Delete(employee);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updateEmployee")]
        public IActionResult Update(Employee employee)
        {
            var result = employeeService.Update(employee);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updateUserDebt")]
        public IActionResult UpdateUserDebt(int userId, decimal amount)
        {
            var result = userService.GetById(userId);
            if(result.Data != null)
            {
                result.Data.Debt -= amount;
                var updateResult = userService.Update(result.Data);
                if(updateResult.Success)
                    return Ok(new SuccessDataResult<User>(result.Data, result.Message));
            }
            return BadRequest(result.Message);
        }
    }
}
