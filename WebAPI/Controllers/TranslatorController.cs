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
    [Route("api/translator")]
    public class TranslatorController : ControllerBase
    {
        ITranslatorService translatorService = InstanceFactory.GetInstance<ITranslatorService>();

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = translatorService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Translator>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }
    }
}
