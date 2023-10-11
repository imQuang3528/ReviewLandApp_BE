using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class DetailHouse:BaseModel
    {
        public string Id { get; set; }
        public string IdListHouse { get; set; }
        public string HouseOwner { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int HouseStatus { get; set; }
    }
}
