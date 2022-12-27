using LibraryManagementSystem.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.MvcWebUI.Models;

namespace LibraryManagementSystem.MvcWebUI.Controllers
{
	public class TranslatorController : Controller
	{
		private ITranslatorService _translatorService;

		public TranslatorController(ITranslatorService translatorService)
		{
			_translatorService = translatorService;
		}

		public IActionResult Index()
		{
			var translators = _translatorService.GetAll().Data;
			return View(translators);
		}
	}
}
