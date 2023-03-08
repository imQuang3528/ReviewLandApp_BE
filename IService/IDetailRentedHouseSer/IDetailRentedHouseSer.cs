using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IDetailRentedHouseSer
{
    public interface IDetailRentedHouseSer
    {
        Task<List<List<object>>> GetDetailRentedHouse();

        Task<bool> InsertUpdateDetailRentedHouse(DetailRentedHouse entity);

        Task<DetailRentedHouse> GetDetailRentedHouseById(object id);
        Task<bool> DeleteDetailRentedHouse(object id);
    }
}
