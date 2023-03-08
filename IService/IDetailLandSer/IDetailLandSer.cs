using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IDetailLandSer
{
    public interface IDetailLandSer
    {
        Task<List<List<object>>> GetListDetailLand();

        Task<bool> InsertUpdateDetailLand(DetailLand entity);

        Task<DetailLand> GetDetailLandById(object id);
        Task<bool> DeleteDetailLand(object id);
    }
}
