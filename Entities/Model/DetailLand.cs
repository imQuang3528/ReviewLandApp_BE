using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class DetailLand:BaseModel
    {
        public string Id { get; set; }
        public string Id_list_land { get; set; }
        public string Land_owner { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Areas { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Status_land { get; set; }

    }
}
