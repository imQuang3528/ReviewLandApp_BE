﻿using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class DetailRentedHouse:BaseModel
    {
        public string Id { get; set; }
        public string IdListRentedHose { get; set; }
        public string RentedHouseOwner { get; set; }
        public string Phone { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public int StatusRoom { get; set; }
    }
}
