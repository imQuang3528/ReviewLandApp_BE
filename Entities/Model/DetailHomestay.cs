using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class DetailHomestay:BaseModel
    {
        public string Id { get; set; }
        public string Id_list_homestay { get; set; }
        public string Homestay_name { get; set; }
        public string Homestay_owner { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Number_room { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Status_homestay { get; set; }
    }
}
