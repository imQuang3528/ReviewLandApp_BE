using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class DetailLand:BaseModel
    {
        public string Id { get; set; }
        public string IdListLand { get; set; }
        public string LandOwner { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int LandStatus { get; set; }

    }
}
