using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.ICateReviewRep
{
    public interface ICateReviewRep
    {
        Task<List<List<object>>> GetListCateReview(int skip,int take,string searchKey);

        Task<CategoryReview> GetCateReviewById(object id);

        Task<bool> SaveCateReview(CategoryReview Entity);

        Task<bool> DeleteCateReview(object id);

    }
}
