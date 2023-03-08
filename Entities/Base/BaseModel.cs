using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Base
{
    public class BaseModel
    {
        public int SKIP { get; set; }
        public int TAKE { get; set; }
        public int TOTALRECORD { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public int? STATUS { get; set; }
        public int? ENTITY_STATUS { get; set; }
    }
}
