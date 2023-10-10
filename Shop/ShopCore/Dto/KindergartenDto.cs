using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCore.Dto
{
    public class KindergartenDto
    {
        public Guid? Id { get; set; }

        public string GroupName { get; set; }

        public int ChildrenCount { get; set; }

        public string KinderGartenName { get; set; }

        public string Teacher { get; set; }

        

    
        //only in database
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //public List<IFormFile> Files { get; set; }

        ////public IEnumerable<FileToApiDto> Image { get; set; }
        //    = new List<FileToApiDto>();
        //    }
    }
}

