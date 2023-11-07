using ShopCore.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
	public class WeatherForecastServices
	{
		public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
		{
			string idOpenWeather = "4f6b9f481986443efd613140d2ba3440";
			string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenWeather}";


			return dto;
		}

	}
}
