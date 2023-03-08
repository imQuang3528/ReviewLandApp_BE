using Entities.Model;
using Entities.ServiceResponse;
using IService.IListLandSer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReviewLandApp.Controllers
{
    [Route("/v1/listlands")]
    [ApiController]
    public class ListLandController : ControllerBase
    {
        private IListLandSer _listLandSer;
        public ListLandController(IListLandSer listLandSer)
        {
            _listLandSer = listLandSer;
        }

        [HttpGet]
        public async Task<ServiceResponse> GetListLand()
        {
            try
            {
                var result =await _listLandSer.GetListLand();
                return new ServiceResponse
                {
                    Data = result,
                    Success = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Get-success"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
        [HttpPost]
        public async Task<ServiceResponse> SaveListLand([FromBody] ListLand entity)
        {
            try
            {             
                var result = await _listLandSer.InsertUpdateListLand(entity);
                return new ServiceResponse
                {
                    Data = result,
                    Success = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "inset-update-success"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse> GetDetailListLand(string id)
        {
            try
            {
                var dic = new Dictionary<string, object>();
                dic.Add("ID", id);
                var result = await _listLandSer.GetListLandById(dic);
                return new ServiceResponse
                {
                    Data = JsonConvert.SerializeObject(result),
                    Success = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "get success"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };
            }
        }
        [HttpDelete("{id}")]
        public async Task<ServiceResponse> DeleteListLand(string id)
        {
            try
            {
                var dic = new Dictionary<string, object>();
                dic.Add("ID", id);
                var result = await _listLandSer.DeleteListLand(dic);
                return new ServiceResponse
                {
                    Data=result,
                    Message="Delete success",
                    StatusCode=(int)HttpStatusCode.OK,
                    Success=true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Success=false,
                    Message=ex.Message,
                    StatusCode=(int)HttpStatusCode.InternalServerError
                };
            }
        }

    }
}
