using Microsoft.AspNetCore.Mvc;
using Shop.Models.OpenWeathers;
using ShopCore.ServiceInterface;

namespace Shop.Controllers
{
	public class OpenWeathersController : Controller
	{
		private readonly IWeatherForecastServices _weatherForecastServices;
		public OpenWeathersController(IWeatherForecastServices weatherForecastServices)
		{
			_weatherForecastServices = weatherForecastServices;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SearchCity(SearchCityViewModel model)
		{
			if (ModelState.IsValid){
				return RedirectToAction("City", "OpenWeathers", new {city=model.CityName});

			}
			
			return View(model);
		}
	}
}
