using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Dto.OpenWeatherDtos
{
    public class OpenWeatherResultDto
    {
        public string City { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }

        public int weatherId { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public string wBase { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }

        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        public int Visibility { get; set; }

        public double windSpeed { get; set; }
        public int windDeg { get; set; }

        public int cloudsAll { get; set; }

        public int Dt { get; set; }

        public int sysType { get; set; }

        public int sysId { get; set; }
        public string sysCountry { get; set; }

        public int sunrise { get; set; }
        public int sunset { get; set; }
        public int timezone { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Citycod { get; set; }






    }


}
