using IService.ICateReviewSer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Entities.Model;
using Utility;
using Entities.ResponseModel;

namespace ReviewLandApp.Controllers
{
    [Route("v1/categoryreview")]
    [ApiController]
    public class CategoryReviewController : ControllerBase
    {
        private ICateReviewSer _cateReviewSer;
        public CategoryReviewController(ICateReviewSer cateReviewSer)
        {
            _cateReviewSer = cateReviewSer;
        }

        [HttpPost("paging")]
        public async Task<APIResult> GetListCategoryReview([FromBody] Dictionary<string, object> pagingRequest)
        {
            try
            {
                var skip = pagingRequest.Get<int>("skip");
                var take = pagingRequest.Get<int>("take");
                var searchKey = pagingRequest.Get<string>("searchKey");
                var result = await _cateReviewSer.GetListCateReview(skip, take, searchKey);
                return new APIResult<object>(result, true, "Get success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, ex.Message);
            }
        }

        [HttpPost]
        public async Task<APIResult> SaveCategoryReview([FromBody] CategoryReview entity)
        {
            try
            {
                var result = await _cateReviewSer.SaveCateReview(entity);
                return new APIResult(true, "Save success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<APIResult> HandleGetDetailCate(string id)
        {
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("ID", id);
                var result = await _cateReviewSer.GetCateReviewById(dic);
                return new APIResult<CategoryReview>(result, true, "Get success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<APIResult> HandleDeleteCate(string id)
        {
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("id", id);
                var result = await _cateReviewSer.DeleteCateReview(dic);
                return new APIResult(true, "Delete success");
            }
            catch (Exception ex)
            {
                return new APIResult(false, ex.Message);
            }
        }
    }
}
