using System.Text.Json.Serialization;

namespace ShopCore.Dto.OpenWeatherDtos
{
	public class Visibility
	{
		[JsonPropertyName("visibility")]
		public int visibility { get; set; }

		
	}
}