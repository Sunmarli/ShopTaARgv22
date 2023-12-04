using Nancy.Json;
using ShopCore.Dto.AccuWeatherDtos;
using ShopCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
	public class AccuWeatherServices : IAccuWeatherServices
	{
		string idAccuWeather = "diCvr9wONQETRTw0JPUDLFAO5w5x5HjR";
		public async Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto)
		{


			using (WebClient client = new WebClient())
			{
				string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={idAccuWeather}&q={dto.City}";
				string json = client.DownloadString(url);
				AccuWeatherResponseRootDto2 accuWeatherResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherResponseRootDto2>>(json).FirstOrDefault();

				dto.Key = accuWeatherResult.Key;

			}

			using (WebClient client2 = new WebClient())
			{
				//Celsius metrics realized in AccuWeatherController.cs
				string url2 = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.Key}?apikey={idAccuWeather}";
				string json2 = client2.DownloadString(url2);
				AccuWeatherResponseRootDto accuWeatherResult2 = new JavaScriptSerializer().Deserialize<AccuWeatherResponseRootDto>(json2);

				dto.Minimum = accuWeatherResult2.DailyForecasts[0].Temperature.Minimum.Value;
				dto.Maximum = accuWeatherResult2.DailyForecasts[0].Temperature.Maximum.Value;
				dto.Link = accuWeatherResult2.DailyForecasts[0].Link;
				dto.Text = accuWeatherResult2.Headline.Text;
				dto.MobileLink = accuWeatherResult2.Headline.MobileLink;
				dto.Date = accuWeatherResult2.DailyForecasts[0].Date;
				//dto.Category = accuWeatherResult2.Headline.Category;
				dto.DayIconPhrase = accuWeatherResult2.DailyForecasts[0].Day.IconPhrase;
				dto.NightIconPhrase = accuWeatherResult2.DailyForecasts[0].Night.IconPhrase;
				dto.Sources = accuWeatherResult2.DailyForecasts[0].Sources;
				dto.DayIcon = accuWeatherResult2.DailyForecasts[0].Day.Icon;
				dto.NighIcon = accuWeatherResult2.DailyForecasts[0].Night.Icon;
			}
			return dto;
		}
	}
}
