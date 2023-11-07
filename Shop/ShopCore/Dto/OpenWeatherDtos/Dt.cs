using System.Text.Json.Serialization;

namespace ShopCore.Dto.OpenWeatherDtos
{
	public class Dt
	{
	
			[JsonPropertyName("dt")]
			public int _dt { get; set; }
		
	}
}