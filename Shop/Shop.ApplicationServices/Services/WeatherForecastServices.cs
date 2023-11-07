using Nancy.Json;
using ShopCore.Dto.OpenWeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ShopCore;
using ShopCore.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class WeatherForecastServices: IWeatherForecastServices
	{
		public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
		{
			string idOpenWeather = "4f6b9f481986443efd613140d2ba3440";
			string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpenWeather}";

			using (WebClient client= new WebClient())
			{
				string json=client.DownloadString(url);
				OpenWeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<OpenWeatherResponseRootDto>(json);

				dto.City = weatherResult.CityName;
				dto.Temp = weatherResult.Main.Temp;
				dto.Feels_like = weatherResult.Main.Feels_like;
				dto.Humidity= weatherResult.Main.Humidity;
				dto.Pressure= weatherResult.Main.Pressure;
				dto.windSpeed = weatherResult.Wind.windSpeed;
				dto.Description = weatherResult.Weather[0].Description;

			}

				return dto;
		}

	}
}
