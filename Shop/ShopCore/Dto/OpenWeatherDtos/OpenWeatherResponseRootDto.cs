using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopCore.Dto.OpenWeatherDtos
{
    internal class OpenWeatherResponseRootDto
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

		[JsonPropertyName("weather")]
		public List<Weather> Weather { get; set; }
		[JsonPropertyName("base")]
		public Base wBase { get; set; }
		[JsonPropertyName("main")]
		public Main Main { get; set; }
		[JsonPropertyName("visibility")]
		public Visibility Visibility { get; set; }

		[JsonPropertyName("wind")]
		public Wind Wind { get; set; }

		[JsonPropertyName("clouds")]
		public Clouds Clouds { get; set; }
		[JsonPropertyName("rain")]
		public Rain Rain { get; set; }

		[JsonPropertyName("dt")]
		public Dt Dt { get; set; }

		[JsonPropertyName("sys")]
		public Sys Sys { get; set; }

		[JsonPropertyName("timezone")]
		public int Timezone { get; set; }
		[JsonPropertyName("id")]
		public int CityId { get; set; }
		[JsonPropertyName("name")]
		public string CityName { get; set; }
		[JsonPropertyName("cod")]
		public int Citycod { get; set; }









	}
}
