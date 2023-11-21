using ShopCore.Dto.CoctailDtos;
using ShopCore.Dto.OpenWeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.ServiceInterface
{
	public interface ICoctailServices
	{
		Task<CoctailResultDto> CoctailResult(CoctailResultDto dto);
	}
}
