using Entities.Model;
using IRepository.ICateReviewRep;
using IService.ICateReviewSer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.CateReviewSer
{
    public class CategoryReviewSer : ICateReviewSer
    {
        private ICateReviewRep _cateReviewRep;
        public CategoryReviewSer(ICateReviewRep cateReviewRep)
        {
            this._cateReviewRep = cateReviewRep;
        }
        public async Task<bool> DeleteCateReview(object id)
        {
            var result = await _cateReviewRep.DeleteCateReview(id);
            return result;
        }

        public async Task<CategoryReview> GetCateReviewById(object id)
        {
            var result = await _cateReviewRep.GetCateReviewById(id);
            return result;
        }

        public async Task<List<List<object>>> GetListCateReview(int skip, int take, string searchKey)
        {
            var result = await _cateReviewRep.GetListCateReview(skip, take, searchKey);
            return result;
        }

        public async Task<bool> SaveCateReview(CategoryReview Entity)
        {
            if (string.IsNullOrEmpty(Entity.Id))
            {
                Entity.Id = Guid.NewGuid().ToString();
                Entity.CreatedDate = DateTime.Now;
                Entity.EntityStatus = 0;
            }
            else
            {
                Entity.EntityStatus = 1;
                Entity.UpdateDate = DateTime.Now;
            }
            var result = await _cateReviewRep.SaveCateReview(Entity);
            return result;
        }
    }
}
