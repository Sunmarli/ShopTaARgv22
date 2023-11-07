using System.Text.Json.Serialization;

namespace ShopCore.Dto.OpenWeatherDtos
{
	public class Sys
	{
		[JsonPropertyName("sysType")]
		public int sysType { get; set; }
		[JsonPropertyName("sysId")]
		public int sysId { get; set; }
		[JsonPropertyName("sysCountry")]
		public string sysCountry { get; set; }
		[JsonPropertyName("sunrise")]
		public int sunrise { get; set; }
		[JsonPropertyName("sunset")]
		public int sunset { get; set; }
	}
}