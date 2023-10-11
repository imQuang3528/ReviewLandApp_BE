using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Entities.ResponseModel
{
    public class APIResult
    {
        public APIResult()
        {

        }

        public APIResult(bool success, string message)
        {
            if (!success)
            {
                this.Success = success;
                this.Message = message;
                this.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                this.Success = success;
                this.Message = message;
                this.StatusCode = (int)HttpStatusCode.OK;
            }
        }
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class APIResult<T> : APIResult
    {
        public APIResult(T result, bool success, string message) : base(success, message)
        {
            if (success)
            {
                this.Data = result;
                this.Success = success;
                this.Message = message;
                this.StatusCode = (int)HttpStatusCode.OK;
            }
        }

        public T Data { get; set; }
    }
}
