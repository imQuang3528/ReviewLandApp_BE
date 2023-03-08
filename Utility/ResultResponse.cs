using Entities.ServiceResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Utility
{
    public static class ResultResponse
    {
        public static ServiceResponse HandleReturnReponse(bool isCorrect, object? data, string message = "")
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            if (isCorrect)
            {
                return new ServiceResponse
                {
                    Data = JsonConvert.SerializeObject(data),
                    Message = "success",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = message,
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            return serviceResponse;
        }
    }
}
