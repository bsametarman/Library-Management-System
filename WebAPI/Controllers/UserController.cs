﻿using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
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
        IUserService userService = new UserManager(new EfUserDal());

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = userService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<User>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }
    }
}
