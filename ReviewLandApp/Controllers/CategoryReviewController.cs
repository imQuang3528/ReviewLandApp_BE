using Entities.ServiceResponse;
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
        public async Task<ServiceResponse> GetListCategoryReview([FromBody] Dictionary<string, object> pagingRequest)
        {
            try
            {
                ServiceResponse serviceResponse = new ServiceResponse();
                var skip = pagingRequest.Get<int>("Skip");
                var take = pagingRequest.Get<int>("Take");
                var searchKey = pagingRequest.Get<string>("searchKey");
                var result = await _cateReviewSer.GetListCateReview(skip, take, searchKey);
                serviceResponse.Data = result;
                return ResultResponse.HandleReturnReponse(true, serviceResponse.Data);
            }
            catch (Exception ex)
            {
                return ResultResponse.HandleReturnReponse(false, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ServiceResponse> SaveCategoryReview([FromBody] CategoryReview entity)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                var result = _cateReviewSer.SaveCateReview(entity);
                return new ServiceResponse
                {
                    Data = "123",
                    Success = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Data = "123",
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse> HandleGetDetailCate(string id)
        {
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("ID", id);
                var result = await _cateReviewSer.GetCateReviewById(dic);
                return ResultResponse.HandleReturnReponse(true, result);
            }
            catch (Exception ex)
            {
                return ResultResponse.HandleReturnReponse(false, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<ServiceResponse> HandleDeleteCate(string id)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            try
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("id", id);
                var result = await _cateReviewSer.DeleteCateReview(dic);
                return ResultResponse.HandleReturnReponse(true, result);
            }
            catch (Exception ex)
            {
                return ResultResponse.HandleReturnReponse(true, ex.Message);
            }
        }
    }
}
