using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IDetailHouseSer
{
    public interface IDetailHouseSer
    {
        Task<List<List<object>>> GetListDetailHouse();

        Task<bool> InsertUpdateDetailHouse(DetailHouse entity);

        Task<DetailHouse> GetListDetailHouseId(object id);
        Task<bool> DeleteDetailHouse(object id);
    }
}
