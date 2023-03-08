using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ServiceResponse
{
    public class ServiceResponse
    {
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
