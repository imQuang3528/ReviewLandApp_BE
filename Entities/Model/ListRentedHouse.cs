using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class ListRentedHouse:BaseModel
    {
        public string IdListRentedHouse { get; set; }
        public string Title { get; set; }
        public string IdCateReview { get; set; }
    }
}
