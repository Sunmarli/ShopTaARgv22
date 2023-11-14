using System.Text.Json.Serialization;

namespace ShopCore.Dto.OpenWeatherDtos
{
	public class Wind
	{
		[JsonPropertyName("speed")]
		public double speed { get; set; }

		[JsonPropertyName("deg")]
		public int windDeg { get; set; }
		[JsonPropertyName("gust")]
		public int gust { get; set; }
	}
}