using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.ICateReviewSer
{
    public interface ICateReviewSer
    {
        Task<List<List<object>>> GetListCateReview(int skip,int take,string searchKey);
        Task<CategoryReview> GetCateReviewById(object id);

        Task<bool> SaveCateReview(CategoryReview Entity);

        Task<bool> DeleteCateReview(object id);
    }
}
