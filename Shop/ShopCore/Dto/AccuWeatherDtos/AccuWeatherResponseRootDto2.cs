using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopCore.Dto.AccuWeatherDtos
{
	public class AccuWeatherResponseRootDto2
	{
		[JsonPropertyName("Key")]
		public string Key { get; set; }

	}
}
