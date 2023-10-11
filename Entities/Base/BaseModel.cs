using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Base
{
    public class BaseModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int TotalRecord { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Status { get; set; }
        public int? EntityStatus { get; set; }
    }
}
