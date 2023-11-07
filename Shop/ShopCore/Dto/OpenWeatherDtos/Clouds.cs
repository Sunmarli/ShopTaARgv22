using System.Text.Json.Serialization;

namespace ShopCore.Dto.OpenWeatherDtos
{
	public class Clouds
	{
		[JsonPropertyName("all")]
		public int cloudsAll { get; set; }
	}
}