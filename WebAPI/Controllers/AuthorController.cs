using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.Business.DependencyResolvers.Ninject;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.ComplexTypes;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        IAuthorService authorService = InstanceFactory.GetInstance<IAuthorService>();

        [HttpGet("getAllAuthors")]
        public IActionResult GetAll()
        {
            var result = authorService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Author>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

		[HttpGet("getAllAuthorsWithDetails")]
		public IActionResult GetAllAuthorsWithDetails()
		{
			var result = authorService.GetAllAuthorsWithDetails();
			if (result.Success)
				return Ok(new SuccessDataResult<List<AuthorDetail>>(result.Data, result.Message));
			return BadRequest(result.Message);
		}

		[HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = authorService.GetById(id);
            if (result.Success)
                return Ok(new SuccessDataResult<Author>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("addAuthor")]
        public IActionResult Add(Author author)
        {
            var result = authorService.Add(author);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpDelete("deleteAuthor")]
        public IActionResult Delete(Author author)
        {
            var result = authorService.Delete(author);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updateAuthor")]
        public IActionResult Update(Author author)
        {
            var result = authorService.Update(author);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
