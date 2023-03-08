using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class ListLand:BaseModel
    {
        public string ID_LIST_LAND { get; set; }
        public string TITLE { get; set; }
        public string ID_CATE_REVIEW { get; set; }
    }
}
