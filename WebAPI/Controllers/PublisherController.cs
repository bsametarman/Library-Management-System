using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/publisher")]
    public class PublisherController : ControllerBase
    {
        IPublisherService publisherService = new PublisherManager(new EfPublisherDal());

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = publisherService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Publisher>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }
    }
}
