using Entities.Model;
using Entities.ResponseModel;
using IService.IListLandSer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<APIResult> GetListLand()
        {
            try
            {
                var result =await _listLandSer.GetListLand();
                return new APIResult<object>(result, true, "Get success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, ex.Message);
            }
        }
        [HttpPost]
        public async Task<APIResult> SaveListLand([FromBody] ListLand entity)
        {
            try
            {             
                var result = await _listLandSer.InsertUpdateListLand(entity);
                return new APIResult<bool>(result, true, "save success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<APIResult> GetDetailListLand(string id)
        {
            try
            {
                var dic = new Dictionary<string, object>();
                dic.Add("ID", id);
                var result = await _listLandSer.GetListLandById(dic);
                return new APIResult<ListLand>(result, true, "Get success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, "Get fail");
            }
        }
        [HttpDelete("{id}")]
        public async Task<APIResult> DeleteListLand(string id)
        {
            try
            {
                var dic = new Dictionary<string, object>();
                dic.Add("ID", id);
                var result = await _listLandSer.DeleteListLand(dic);
                return new APIResult<bool>(result, true, "Delete success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, ex.Message);
            }
        }

    }
}
