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
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        IAuthorService authorService = InstanceFactory.GetInstance<IAuthorService>();

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = authorService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Author>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }
    }
}
