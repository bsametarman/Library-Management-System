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

        [HttpGet("getAllTranslators")]
        public IActionResult GetAll()
        {
            var result = translatorService.GetAll();
            if (result.Success)
                return Ok(new SuccessDataResult<List<Translator>>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = translatorService.GetById(id);
            if (result.Success)
                return Ok(new SuccessDataResult<Translator>(result.Data, result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("addTranslator")]
        public IActionResult Add(Translator translator)
        {
            var result = translatorService.Add(translator);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpDelete("deleteTranslator")]
        public IActionResult Delete(Translator translator)
        {
            var result = translatorService.Delete(translator);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }

        [HttpPost("updateTranslator")]
        public IActionResult Update(Translator translator)
        {
            var result = translatorService.Update(translator);
            if (result.Success)
                return Ok(new SuccessResult(result.Message));
            return BadRequest(result.Message);
        }
    }
}
