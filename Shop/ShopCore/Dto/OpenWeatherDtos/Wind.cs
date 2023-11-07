using System.Text.Json.Serialization;

namespace ShopCore.Dto.OpenWeatherDtos
{
	public class Wind
	{
		[JsonPropertyName("windSpeed")]
		public double windSpeed { get; set; }

		[JsonPropertyName("windDeg")]
		public int windDeg { get; set; }
		[JsonPropertyName("gust")]
		public int gust { get; set; }
	}
}