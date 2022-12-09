using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/translator")]
    public class TranslatorController
    {
        ITranslatorService translatorService = new TranslatorManager(new EfTranslatorDal());

        [HttpGet]
        public List<Translator> GetAll()
        {
            return translatorService.GetAll();
        }
    }
}
