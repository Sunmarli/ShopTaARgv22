﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopCore.Dto.ChuckNorrisDtos
{
	public class ChuckNorrisResultDto
	{
		public List<string> Categories { get; set; }
		
		public string CreatedAt { get; set; }

		
		public string IconUrl { get; set; }

		
		public string Id { get; set; }

		
		public string UpdatedAt { get; set; }
		
		public string Url { get; set; }

		public string Value { get; set; }
	}
}
