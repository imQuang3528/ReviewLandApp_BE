using Entities.AppSetting;
using Entities.Model;
using IRepository.ICateReviewRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CateReviewRep
{
    public class CategoryReviewRep : BaseRepository, ICateReviewRep
    {
        private IOptions<AppSetting> _appsetting;
        public CategoryReviewRep(IOptions<AppSetting> appsetting) : base(appsetting)
        {
            this._appsetting = appsetting;
        }
        public async Task<bool> DeleteCateReview(object id)
        {
            var proc = "CATEGORY_REVIEW_DELETE";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }

        public async Task<CategoryReview> GetCateReviewById(object id)
        {
            var proc = "CATEGORY_REVIEW_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<CategoryReview>(proc, id);
            return result;
        }

        public async Task<List<List<object>>> GetListCateReview(int skip, int take, string searchKey)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("SKIP", skip);
            param.Add("TAKE", take);
            param.Add("KEY", searchKey);
            var proc = "CATEGORY_REVIEW_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(CategoryReview) }, proc, param);
            return result;
        }

        public async Task<bool> SaveCateReview(CategoryReview Entity)
        {
            var proc = "CATEGORY_REVIEW_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, Entity);
            return result;
        }
    }
}
