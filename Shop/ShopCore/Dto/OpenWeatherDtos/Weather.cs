namespace ShopCore.Dto.OpenWeatherDtos;

using System.Text.Json.Serialization;

	public class Weather
	{
		[JsonPropertyName("weatherId")]
		public int weatherId { get; set; }

		[JsonPropertyName("Main")]
		public string Main { get; set; }

		[JsonPropertyName("Description")]
		public string Description { get; set; }

		[JsonPropertyName("Icon")]
		public string Icon { get; set; }

	}
