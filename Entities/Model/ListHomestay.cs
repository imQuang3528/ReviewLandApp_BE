using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class ListHomestay:BaseModel
    {
        public string IdListHomeStay { get; set; }
        public string Title { get; set; }
        public string IdCateReview { get; set; }
    }
}
