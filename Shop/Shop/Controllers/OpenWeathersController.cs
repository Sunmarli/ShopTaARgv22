using Microsoft.AspNetCore.Mvc;
using Shop.Models.OpenWeathers;
using ShopCore.Dto.OpenWeatherDtos;
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
		[HttpGet]
		public IActionResult City(string city)
		{
			OpenWeatherResultDto dto = new();
			dto.City = city;
			_weatherForecastServices.OpenWeatherResult(dto);
			OpenWeatherViewModel vm = new();

			vm.City = dto.City;
			vm.Lon = dto.Lon;
			vm.Lat = dto.Lat;
			vm.weatherId = dto.weatherId;
			vm.Main = dto.Main;
			vm.Description = dto.Description;
			vm.Icon = dto.Icon;
			vm.wBase = dto.wBase;
			vm.Temp = dto.Temp;
			vm.Feels_like = dto.Feels_like;
			vm.Temp_min = dto.Temp_min;
			vm.Temp_max = dto.Temp_max;
			vm.Pressure = dto.Pressure;
			vm.Humidity = dto.Humidity;
			vm.Visibility = dto.Visibility;
			vm.windSpeed = dto.windSpeed;
			vm.windDeg = dto.windDeg;
			vm.cloudsAll = dto.cloudsAll;
			vm.Dt = dto.Dt;
			vm.sysType = dto.sysType;
			vm.sysId = dto.sysId;
			vm.sysCountry = dto.sysCountry;
			vm.sunrise = dto.sunrise;
			vm.timezone = dto.timezone;
			vm.CityId = dto.CityId;
			vm.CityName = dto.CityName;
			vm.Citycod = dto.Citycod;

			return View(vm);

		}
	}
}
