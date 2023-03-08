using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class ListRentedHouse:BaseModel
    {
        public string Id_list_rented_house { get; set; }
        public string Title { get; set; }
        public string Id_cate_review { get; set; }
    }
}
