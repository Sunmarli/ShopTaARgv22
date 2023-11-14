using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Models.ChuckNorris;
using Shop.Models.OpenWeathers;
using ShopCore.Dto.ChuckNorrisDtos;
using ShopCore.ServiceInterface;

namespace Shop.Controllers
{
	public class ChuckNorrisController : Controller
	{
		private readonly IChuckNorrisServices _chuckNorrisServices;
		public ChuckNorrisController(IChuckNorrisServices chuckNorrisServices)
		{
			_chuckNorrisServices = chuckNorrisServices;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult GenerateJoke(JokeGeneratorViewModel model)
		{
			if (ModelState.IsValid)
			{
				return RedirectToAction("Joke", "ChuckNorris");

			}

			return View(model);
		}
		[HttpGet]
		public IActionResult Joke(string value)
		{
			ChuckNorrisResultDto dto = new();
			dto.Value = value;

			_chuckNorrisServices.ChuckNorrisResult(dto);
			ChuckNorrisViewModel vm = new();

			vm.Value = dto.Value;

			return View(vm);
		}
	}
}
