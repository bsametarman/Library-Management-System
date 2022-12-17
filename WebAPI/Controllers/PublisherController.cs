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
    [Route("api/publisher")]
    public class PublisherController : ControllerBase
    {
        IPublisherService publisherService = InstanceFactory.GetInstance<IPublisherService>();

        [HttpGet("getAllPublishers")]
        public IActionResult GetAll()
        {
            var result = publisherService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Publisher>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = publisherService.GetById(id);
            if (result.Success)
                return Ok(new SuccessDataResult<Publisher>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("addPublisher")]
        public IActionResult Add(Publisher publisher)
        {
            var result = publisherService.Add(publisher);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpDelete("deletePublisher")]
        public IActionResult Delete(Publisher publisher)
        {
            var result = publisherService.Delete(publisher);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updatePublisher")]
        public IActionResult Update(Publisher publisher)
        {
            var result = publisherService.Update(publisher);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
