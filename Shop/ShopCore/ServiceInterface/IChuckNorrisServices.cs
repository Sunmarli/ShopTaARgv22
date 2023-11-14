using ShopCore.Dto.ChuckNorrisDtos;
using ShopCore.Dto.OpenWeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.ServiceInterface
{
	public interface IChuckNorrisServices
	{
		Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto);
	}
}
