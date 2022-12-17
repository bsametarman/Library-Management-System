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
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        IUserService userService = InstanceFactory.GetInstance<IUserService>();

        [HttpGet("getAllUsers")]
        public IActionResult GetAll()
        {
            var result = userService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<User>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = userService.GetById(id);
            if (result.Success)
                return Ok(new SuccessDataResult<User>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("addUser")]
        public IActionResult Add(User user)
        {
            var result = userService.Add(user);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpDelete("deleteUser")]
        public IActionResult Delete(User user)
        {
            var result = userService.Delete(user);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updateUser")]
        public IActionResult Update(User user)
        {
            var result = userService.Update(user);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
