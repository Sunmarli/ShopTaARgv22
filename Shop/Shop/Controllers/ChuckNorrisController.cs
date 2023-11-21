using Microsoft.AspNetCore.Mvc;

using Shop.Models.ChuckNorris;

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
			//if (ModelState.IsValid)
			{
				//return RedirectToAction("Joke", "ChuckNorris");
				return RedirectToAction("Joke", "ChuckNorris");

			}

			//return View(model);
		}
		[HttpGet]
		public IActionResult Joke(string joke)
		{

			ChuckNorrisResultDto dto = new();
			dto.Value = joke;

			_chuckNorrisServices.ChuckNorrisResult(dto);
			ChuckNorrisViewModel vm = new();

			vm.Categories = dto.Categories;
			vm.CreatedAt = dto.CreatedAt;
			vm.IconUrl = dto.IconUrl;
			vm.Id = dto.Id;
			vm.UpdatedAt = dto.UpdatedAt;
			vm.Url = dto.Url;
			vm.Value = dto.Value;

			return View(vm);
		}
	}
}
