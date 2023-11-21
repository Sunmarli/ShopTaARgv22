using System;
using System.Collections.Generic;
using System.Net;

using Nancy.Json;
using ShopCore.Dto.ChuckNorrisDtos;
using ShopCore.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
	public class ChuckNorrisServices: IChuckNorrisServices
	{
		public async Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto)
		{
			//string idChuckNorris = "4f6b9f481986443efd613140d2ba3440";
			string url = $"https://api.chucknorris.io/jokes/random";

			using (WebClient client = new WebClient())
			{
				string json = client.DownloadString(url);
				ChuckNorrisResponseRootDto chuckNorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisResponseRootDto>(json);

				dto.Value = chuckNorrisResult.Value;
				dto.Categories = chuckNorrisResult.Categories;
				dto.CreatedAt = chuckNorrisResult.CreatedAt;
				dto.IconUrl = chuckNorrisResult.IconUrl;
				dto.Id = chuckNorrisResult.Id;
				dto.UpdatedAt = chuckNorrisResult.UpdatedAt;
				dto.Url = chuckNorrisResult.Url;
				dto.Value = chuckNorrisResult.Value;

			}

			return dto;
		}
	}
}
