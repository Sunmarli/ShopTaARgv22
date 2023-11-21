using ShopCore.Dto.OpenWeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopCore.Dto.CoctailDtos
{
	public class CoctailResponseRootDto
	{
		[JsonPropertyName("drinks")]
		public List<Drink> drinks { get; set; }
	}
}
