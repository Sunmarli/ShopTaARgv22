using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Dto.AccuWeatherDtos
{
	public class AccuWeatherResultDto
	{

		public string City { get; set; }
		public string Key { get; set; }
		public int Minimum { get; set; }
		public int Maximum { get; set; }
		public string Link { get; set; }
		public DateTime Date { get; set; }
		public string Text { get; set; }
		// public string Category { get; set; }
		public string MobileLink { get; set; }
		public string DayIconPhrase { get; set; }
		public string NightIconPhrase { get; set; }
		public List<string> Sources { get; set; }
		public int DayIcon { get; set; }
		public int NighIcon { get; set; }
	}
}
