using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
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
        public List<Publisher> GetAll()
        {
            return publisherService.GetAll();
        }
    }
}
