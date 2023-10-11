using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Model
{
    public class DetailHomestay:BaseModel
    {
        public string Id { get; set; }
        public string IdListHomeStay { get; set; }
        public string HomeStayName { get; set; }
        public string HomeStayOwner { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int NumberRoom{ get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int HomeStayStatus { get; set; }
    }
}
